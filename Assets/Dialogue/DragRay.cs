using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRay : MonoBehaviour
{
    [SerializeField] private LayerMask dialogueLayer;
    [SerializeField] private LayerMask dropLayer;
    private Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
    private RaycastHit objectHit;
    private DraggableDialogue draggable;
    private bool isDialogueHit = false; //bool key so that its not just constantly checking voids
    private void Update() //if, in every frame...
    {
        if (Input.GetMouseButtonDown(0)) //the mouse button is held down...
        {
            if (Physics.Raycast(ray, out objectHit, Mathf.Infinity, dialogueLayer)) //fire a raycast, and if it hits dialogue...
            {
               isDialogueHit = true;
               draggable = objectHit.collider.transform.GetComponent<DraggableDialogue>();
               draggable.OnDialogueDrag();
            }
        }
        else if (Input.GetMouseButtonUp(0) && isDialogueHit) //the player releases the dialogue...
        {
            if (Physics.Raycast(ray, out objectHit, Mathf.Infinity, dropLayer)) //fire another ray, and if it hits a dropZone...
            {
                draggable.OnDialogueRelease(objectHit.collider.transform);
            }
            else
            {
                draggable.OnDialogueRelease();
            }
            isDialogueHit = false;
        }
    }

    
    
    
        //if (Raycast.hit gameObject and mouse still holding)
            //
        //transform.position = mouse.position //TWEEN THIS, slower at the very start then faster following behind, make it floaty
        
        
        //if (mouse.let.go && raycast.hit Collision2d && area.matches.keyword)
        //send
        
        
        
        //EACH GAME OBJECT NEEDS AN ID FOR THE AREA so that it knows whats a valid area to be dropped in
        
        
        
        //CODE GRAVEYARD 
     /*if (!isDialogueHit)
                    {
                        if (objectHit.transform.GetComponent<DraggableDialogue>()) //and that something is dialogue...
                        {
                            isDialogueHit = true; //set this key to true
                        }
                    }
                    else //and when the key is true....
                    {
                        Draggable = objectHit.transform.GetComponent<DraggableDialogue>();
                        Draggable.OnDialogueDrag(); //call the drag action
                    }*/
}
