using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance; //shit code but we make it an instance so everyhting gets a quick reference to it. TERRIBLE TERRIBLE TERRIBLE 
    
    [Header("Dialogue Data")]
    public DialogueNode[] dialogueNodes; //Each "set" of dialogue
    private int currentNode = 0; //which "scene" you are currently in, represented by the int number
    
    [Header("Voice Spawn Points")]
    public RectTransform spawnBarbarian;
    public RectTransform spawnWizard;
    public RectTransform spawnBard;
    
    [Header("UI References")]
    public TMP_Text dialogueBox;               // for normal dialogue
    public Transform floatingTextParent;       // parent for floating lines
    public GameObject floatingTextPrefab;      // prefab for floating text
    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (dialogueNodes != null && dialogueNodes.Length > 0)
        {
            ShowDialogueAtScene(currentNode); //initializes us at the beginning when the program starts, 
        }
    }

    
    public void ProgressDialogue() //call this to progress manually
    {
        DialogueNode node = dialogueNodes[currentNode];
        if(node.nextNode != null && node.nextNode.Length > 0)
        {
            ShowDialogueAtScene(node.nextNode[0]); //show next in line
        }
    }
    public void ShowDialogueAtScene(int sceneIndex) //process that prints lines on the screen
    {
        if (dialogueNodes == null || sceneIndex < 0 || sceneIndex >= dialogueNodes.Length)
        {
            Debug.LogWarning("Dialogue Node is out of range.");
            return;
        }
        
        currentNode = sceneIndex; 
        DialogueNode dialogueNode = dialogueNodes[sceneIndex]; //variable made equal to the set of dialogue at given scene

        foreach (Transform child in floatingTextParent) //destroy old text
            Destroy(child.gameObject);
        
        foreach (var line in dialogueNode.dialogue) //for every line in the given scene, generate them like this
        {
            switch (line.type) //different types have different effects
            {
                case DialogueStyle.Floating: //voices dialogue
                {
                    GameObject ft = Instantiate(floatingTextPrefab, floatingTextParent);
                    RectTransform rt = ft.GetComponent<RectTransform>();

                    switch (line.characterID)
                    {
                        case "wizard":
                            ft.transform.position = spawnWizard.position;
                            break;
                        case "bard":
                            ft.transform.position = spawnBard.position;
                            break;
                        case "barbarian":
                            ft.transform.position = spawnBarbarian.position;
                            break;
                        default:
                            rt.anchoredPosition = new Vector2(Random.Range(-200f, 200f), Random.Range(-100f, 100f));
                            break;
                    }

                    TMP_Text ftText = ft.GetComponent<TMP_Text>();
                    if (ftText == null)
                    {
                        Debug.LogError("floatingTextPrefab must contain a TMP_Text / TextMeshProUGUI component.");
                        continue;
                    }
                    ftText.text = line.text;
                    ftText.color = line.textColor;
                    ftText.fontSize = line.fontSize;

                    // per-instance material for outline if requested
                    if (line.outlineWidth > 0f)
                    {
                        Material mat = new Material(ftText.fontSharedMaterial);
                        ftText.fontMaterial = mat;
                        mat.SetFloat(ShaderUtilities.ID_OutlineWidth, line.outlineWidth);
                        mat.SetColor(ShaderUtilities.ID_OutlineColor, line.outlineColor);
                    }
                    
                    // ensure it has a CanvasGroup for dragging
                    if (ft.GetComponent<CanvasGroup>() == null)
                        ft.AddComponent<CanvasGroup>();

                    // add/drill the draggable script and assign character ID
                    DraggableText drag = ft.GetComponent<DraggableText>();
                    if (drag == null) drag = ft.AddComponent<DraggableText>();
                    drag.characterID = line.characterID;
                    break;
                }
                case DialogueStyle.Normal: //normal dialogue
                {
                    dialogueBox.text = line.text;
                    dialogueBox.color = line.textColor;
                    dialogueBox.fontSize = line.fontSize;
                    if (line.outlineWidth > 0f)
                    {
                        // copy shared material into an instance so we don't change every TMP using this font
                        Material mat = new Material(dialogueBox.fontSharedMaterial);
                        dialogueBox.fontMaterial = mat;
                        mat.SetFloat(ShaderUtilities.ID_OutlineWidth, line.outlineWidth);
                        mat.SetColor(ShaderUtilities.ID_OutlineColor, line.outlineColor);
                    }
                    break;
                }
            }
        }
    }
    public void HandleDrag(string characterID, string zoneID, GameObject draggedObject = null)
    {
        DialogueNode node = dialogueNodes[currentNode];

        foreach (var choice in node.choices)
        {
            if (choice.characterID == characterID && choice.zoneID == zoneID)
            {
                if (draggedObject != null) Destroy(draggedObject);

                ShowDialogueAtScene(choice.nextNode);
                return;
            }
        }

        Debug.Log($"No matching drag choice for {characterID} in {zoneID}");
    }
}
