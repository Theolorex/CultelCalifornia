using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DraggableDialogue : MonoBehaviour
{
    [System.Serializable]
    public class DialogueEvent : UnityEvent<DraggableDialogue> {} //define event, call invoke from this

    public DialogueEvent DialogueChosen;
    
    private bool startedDragging = false;
    private Vector3 startPosition;

    public float baseFollowSpeed = 8f; //random float value and public FOR NOW, basic float speed that the dialogue will ALWAYS move at
    public float maxFollowSpeed = 20f; //random float value and public FOR NOW, limit on speed the dialogue can move depending on how far the cursor is
    public float distanceMultiplier = 1.5f; //random float value and public FOR NOW, how much being far from the cursor affects speed
    
    private float distance;
    private float speed; //the end result
    
    public void OnDialogueDrag()
    {
        if (!startedDragging)
        {
            startPosition = transform.position; //record original position
            startedDragging = true;
        }
        else
        {
            distance = Vector3.Distance(transform.position, Input.mousePosition);

            speed = baseFollowSpeed + Mathf.Min(distance * distanceMultiplier, maxFollowSpeed); //base speed +
            //either the distance multiplied by the distanceMultiplier, or the maxFollowSpeed cap
            //this is used to approx a variable speed
            
            transform.position = Vector3.Lerp(transform.position, Input.mousePosition, Time.deltaTime * speed); //lerp makes it move smoothly
            //first two parameters are the object affected, and the destination, the third is the SPEED of it, which is determined by previous code
            //transform.position = Input.mousePosition; //CHANGE THIS, TWEEN THIS PLEEAAASE FLOATY DIALOGUE
        }
    }

    public void OnDialogueRelease()
    {
        transform.position = startPosition; //if nothing was hit, send it back to the original location
        //LERP IT, make the previous a func that both can call
    }

    public void OnDialogueRelease(Transform dropZone) //if dropZone hit...
    {
        if (CompareTag(dropZone.tag)) //and the tag on both the dialogue and the dropZone is the same...
        {
            //ok this fully now depends on whether the choice is attached to the
            //dialogue or dropzone but im going to assume dialogue for nbow
            DialogueChosen.Invoke(this);
        }
        
    }
}
