using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[Serializable]
public class jsonData
{
    public string id;
    public string tank;
    public string wizard;
    public string bard;
    public int delay;
    public bool choice;
    public string goesTo;
}
public class Dman : MonoBehaviour
{
    public ScriptDialogue dialogue;
    public TextMeshPro tankText;
    public TextMeshPro wizardText;
    public TextMeshPro bardText;
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, Dictionary<string, string>> diaData = new Dictionary<string, Dictionary<string, string>>();
        foreach (var beat in dialogue.textFiles)
        {
            jsonData data = JsonUtility.FromJson<jsonData>(beat.file.text);
            var entry = new Dictionary<string, string>()
            {
                {"tank", data.tank },
                {"wizard", data.wizard },
                {"bard", data.bard },
                {"delay", data.delay.ToString() },
                {"choice", data.choice.ToString() },
                {"goesTo", data.goesTo }
            };
            diaData[data.id] = entry;
        }

        StartCoroutine(Display(diaData["start"], diaData));


    }

    IEnumerator Display(Dictionary<string, string> entry, Dictionary<string, Dictionary<string, string>> diaData)
    {
        tankText.text = entry["tank"];
        wizardText.text = entry["wizard"];
        bardText.text = entry["bard"];
        yield return new WaitForSeconds(float.Parse(entry["delay"]));
        if (bool.Parse(entry["choice"]))
        {
            // choice shit will go here
        }
        else
        {
            StartCoroutine(Display(diaData[entry["goesTo"]], diaData));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
