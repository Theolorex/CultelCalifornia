using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue")]
public class ScriptDialogue : ScriptableObject
{
    [Min(1)] public int numFiles;
    [System.Serializable]
    public class NamedFile
    {
        public string key;
        public TextAsset file;
    }

    public List<NamedFile> textFiles = new List<NamedFile>();

    private void OnValidate()//gets called when the obj is modified
    {
        if (numFiles < 1) numFiles = 1;

        // change size of list to match numFiles, grows
        while (textFiles.Count < numFiles)
            textFiles.Add(null);

        // changes size of list to match numFiles, shrinks
        while (textFiles.Count > numFiles)
            textFiles.RemoveAt(textFiles.Count - 1);
    }
    
    
}
