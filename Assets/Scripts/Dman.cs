using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class jsonData
{
    public string id;
    public string tank;
    public string wizard;
    public string bard;
    public int delay;
    public bool choice;
}
public class Dman : MonoBehaviour
{
    public ScriptDialogue dialogue;
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
                {"choice", data.choice.ToString() }
            };
            diaData[data.id] = entry;
        }

        Display(diaData["start"]);


    }

    public void Display(Dictionary<string, string> entry)
    {
        Debug.Log(entry["tank"]);
        Debug.Log(entry["wizard"]);
        Debug.Log(entry["bard"]);
        Debug.Log(entry["delay"]);
        Debug.Log(entry["choice"]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
