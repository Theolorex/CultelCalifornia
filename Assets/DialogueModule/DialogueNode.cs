
using UnityEngine; //THIS IS FOR DEFINING WHAT THE NODES CAN DO 

    [System.Serializable]
    public enum DialogueStyle //aesthetic of the dialogue
    {
        Normal, //normal dialogue? dont know if it'll be different
        Floating //voices, dont know if normal dialogue'll include this
    }

    [System.Serializable]
    public class DialogueLine //class that defines what the lines actually are
    {
        public string text; //what do you think
        public DialogueStyle type = DialogueStyle.Normal; //default is normal, but for voices should be swapped
        
        //fun customize line color and text, differentiate who is talking or how
        public Color textColor = Color.white; 
        public Color outlineColor = Color.black;
        public float outlineWidth = 0.2f;
        public int fontSize = 42;
        public string characterID; //which character is speaking
    }

    [System.Serializable]
    public class DialogueNode //what actually holds it all
    {
        public DialogueLine[] dialogue; //the dialogue being said at the moment
        public DragChoice[] choices; //the options the player can pick 
        public int[] nextNode; //the idea is create an array list that'll chain to the next node depedning on choice
    }

    [System.Serializable]
    public class DragChoice
    {
        public string characterID;   //must match line.characterID
        public string zoneID;        //must match DropZone.zoneID
        public int nextNode;         //index of next dialogue scene
    }

