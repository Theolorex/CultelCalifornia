using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TempDialogueCode : MonoBehaviour
{
    //representation of how to call draggabledialogue's event
    
    [SerializeField] private DraggableDialogue dialogue; //serialized for a reference though i think depending on how dialogue is stored this will need to be dif

    void Start()
    {
        dialogue.DialogueChosen.AddListener(OnDialogueChosen); //so word by word explanation
        
        //dialogue: our own variable we defined above of the type draggabledialogue
        
        //DialogueChosen: the variable defined inside DraggableDialogue thats the type of the event
        
        //AddListener(): an implicit function that allows any given function to "listen" for when the given event is called
        
        //OnDialogueChosen: pass the function we declare below to the AddListener func
    }

    private void OnDialogueChosen(DraggableDialogue dialogue)
    {
        //whatever code to cycle through dialogue and display more
    }
}
