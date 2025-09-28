using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance; 
    
    [Header("Dialogue Data")]
    public DialogueNode[] dialogueNodes; 
    private int currentNode = 0; 
    
    [Header("Drop Zone")]
    public GameObject dropZonePrefab;
    
    [Header("Voice Spawn Points")]
    public RectTransform spawnBarbarian;
    public RectTransform spawnWizard;
    public RectTransform spawnBard;
    
    [Header("UI References")]
    public TMP_Text dialogueBox;               
    public Transform floatingTextParent;       
    public GameObject floatingTextPrefab;      
    
    [Header("Typing Settings")]
    public float typingSpeed = 0.03f; // seconds per character
    public float autoProgressDelay = 1f; // pause before auto-progress
    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (dialogueNodes != null && dialogueNodes.Length > 0)
        {
            ShowDialogueAtScene(currentNode); 
        }
    }

    public void ProgressDialogue() 
    {
        DialogueNode node = dialogueNodes[currentNode];
        if (node.nextNode != null && node.nextNode.Length > 0)
        {
            ShowDialogueAtScene(node.nextNode[0]); 
        }
    }

    public void ShowDialogueAtScene(int sceneIndex) 
    {
        dialogueBox.text = "...";
        if (dialogueNodes == null || sceneIndex < 0 || sceneIndex >= dialogueNodes.Length)
        {
            Debug.LogWarning("Dialogue Node is out of range.");
            return;
        }

        currentNode = sceneIndex; 
        DialogueNode dialogueNode = dialogueNodes[sceneIndex]; 

        foreach (Transform child in floatingTextParent) 
            Destroy(child.gameObject);

        // Start coroutine to process lines one by one
        StartCoroutine(ProcessDialogueLines(dialogueNode));
    }

    private IEnumerator ProcessDialogueLines(DialogueNode dialogueNode)
    {
        foreach (var line in dialogueNode.dialogue)
        {
            switch (line.type)
            {
                case DialogueStyle.Floating:
                {
                    GameObject ft = Instantiate(floatingTextPrefab, floatingTextParent);
                    RectTransform rt = ft.GetComponent<RectTransform>();

                    switch (line.characterID)
                    {
                        case "wizard": ft.transform.position = spawnWizard.position; break;
                        case "bard": ft.transform.position = spawnBard.position; break;
                        case "barbarian": ft.transform.position = spawnBarbarian.position; break;
                        default: rt.anchoredPosition = new Vector2(Random.Range(-200f, 200f), Random.Range(-100f, 100f)); break;
                    }

                    TMP_Text ftText = ft.GetComponent<TMP_Text>();
                    if (ftText == null)
                    {
                        Debug.LogError("floatingTextPrefab must contain a TMP_Text / TextMeshProUGUI component.");
                        continue;
                    }

                    ftText.color = line.textColor;
                    ftText.fontSize = line.fontSize;

                    if (line.outlineWidth > 0f)
                    {
                        Material mat = new Material(ftText.fontSharedMaterial);
                        ftText.fontMaterial = mat;
                        mat.SetFloat(ShaderUtilities.ID_OutlineWidth, line.outlineWidth);
                        mat.SetColor(ShaderUtilities.ID_OutlineColor, line.outlineColor);
                    }

                    if (ft.GetComponent<CanvasGroup>() == null)
                        ft.AddComponent<CanvasGroup>();

                    DraggableText drag = ft.GetComponent<DraggableText>();
                    if (drag == null) drag = ft.AddComponent<DraggableText>();
                    drag.characterID = line.characterID;

                    // Typewriter effect for floating text
                    yield return StartCoroutine(TypeFloatingText(ftText, line.text));

                    // Spawn drop zone if not auto-progress
                    if (!line.autoProgress && dropZonePrefab != null)
                    {
                        GameObject dz = Instantiate(dropZonePrefab, floatingTextParent);
                        RectTransform dzRect = dz.GetComponent<RectTransform>();
                        dzRect.anchoredPosition = line.hitboxPosition;
                    }
                    else if (line.autoProgress && dialogueNode.nextNode.Length > 0)
                    {
                        yield return new WaitForSeconds(autoProgressDelay);
                        ShowDialogueAtScene(dialogueNode.nextNode[0]);
                        yield break; // stop processing further lines
                    }
                    break;
                }

                case DialogueStyle.Normal:
                {
                    // Typewriter effect for normal dialogue
                    yield return StartCoroutine(TypeNormalText(line));

                    if (line.autoProgress && dialogueNode.nextNode.Length > 0)
                    {
                        yield return new WaitForSeconds(autoProgressDelay);
                        ShowDialogueAtScene(dialogueNode.nextNode[0]);
                        yield break;
                    }
                    break;
                }
            }
            Debug.Log($"[DialogueManager] Showing line: '{line.text}' type={line.type} autoProgress={line.autoProgress}");
        }
    }

    private IEnumerator TypeNormalText(DialogueLine line)
    {
        dialogueBox.text = "";
        dialogueBox.color = line.textColor;
        dialogueBox.fontSize = line.fontSize;

        if (line.outlineWidth > 0f)
        {
            Material mat = new Material(dialogueBox.fontSharedMaterial);
            dialogueBox.fontMaterial = mat;
            mat.SetFloat(ShaderUtilities.ID_OutlineWidth, line.outlineWidth);
            mat.SetColor(ShaderUtilities.ID_OutlineColor, line.outlineColor);
        }

        foreach (char c in line.text)
        {
            dialogueBox.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private IEnumerator TypeFloatingText(TMP_Text target, string fullText)
    {
        target.text = "";
        foreach (char c in fullText)
        {
            target.text += c;
            yield return new WaitForSeconds(typingSpeed);
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