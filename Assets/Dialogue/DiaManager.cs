using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;

public class DiaManager : MonoBehaviour
{
    public TextMeshPro tankText;
    public TextMeshPro wizardText;
    public TextMeshPro bardText;
    public allDialogue dia;
    public SceneMoveNew sm;
    public bool tavernFight = false;
    // Start is called before the first frame update
    void Start()
    {
        String[] diaArray = dia.allDial;
    }

    // Update is called once per frame
    void Update()
    {
        String[] diaArray = dia.allDial;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(showThing(diaArray));
        }
    }

    IEnumerator showThing(String[] diaArray)
    {

        for (int i = 0; i < 31; i++)
        {
            tankText.text = diaArray[i];
            wizardText.text = diaArray[i = i + 1];
            bardText.text = diaArray[i = i + 2];
            yield return new WaitForSeconds(2);
        }

        tankText.text = "Kill or Spare?";
        wizardText.text = "Kill them! It is the rational thing to do";
        bardText.text = "Spare! He looks fun";

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        string choice = CastThing();
        if (choice == "Tank" || choice == "Wizard")
        {
            tankText.text = "You chose to kill them";
            wizardText.text = "Good choice";
            bardText.text = "I guess so";
            sm.SceneSwitch(2);
        }
        else if (choice == "Bard")
        {
            tankText.text = "You chose to spare them";
            wizardText.text = "Foolish choice";
            bardText.text = "Yay! Fun!";
            sm.SceneSwitch(7);
            tavernFight = true;
            yield return new WaitForSeconds(2);

            for (int j = 71; j < 81; j++)
            {
                tankText.text = diaArray[j];
                wizardText.text = diaArray[j = j + 1];
                bardText.text = diaArray[j = j + 2];
                yield return new WaitForSeconds(2);

            }
        }

        

    }

    String CastThing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("doing it!");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit " + hit.transform.name);
                if (hit.transform.tag == "Tank")
                {
                    return "Tank";
                }
                if (hit.transform.tag == "Wizard")
                {
                    return "Wizard";
                }
                if (hit.transform.tag == "Bard")
                {
                    return "Bard";
                }
                else
                {
                    return "Wizard";
                }
                
            }
            return "Wizard";
        }
        return "Wizard";
    }
}
