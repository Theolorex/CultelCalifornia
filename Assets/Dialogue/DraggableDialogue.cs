using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableDialogue : MonoBehaviour
{
    private bool startedDragging = false;
    private Vector3 startPosition;
    public void OnDialogueDrag()
    {
        if (!startedDragging)
        {
            startPosition = transform.position; //record original position
            startedDragging = true;
        }
        else
        {
            transform.position = Input.mousePosition; //CHANGE THIS, TWEEN THIS PLEEAAASE FLOATY DIALOGUE
        }
    }

    public void OnDialogueRelease()
    {
        transform.position = startPosition; //if nothing was hit, send it back to the original location
    }

    public void OnDialogueRelease(Tranform dropZone)
    {
        //check if dropZone is valid for teh thing
    }
}
