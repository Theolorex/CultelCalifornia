using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneMoveNew : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    Vector3 firstPos;
    Vector3 secondPos;
    Vector3 thirdPos;
    Vector3 fourthPos;
    Vector3 fifthPos;
    Vector3 sixthPos;
    Vector3 seventhPos;
    Vector3 eighthPos;
    Vector3 ninthPos;
    public Renderer ren1;
    public Renderer ren2;
    public Renderer ren3;
    public Renderer ren4;
    public Renderer ren5;
    public Renderer ren6;
    public Renderer ren7;
    public Renderer ren8;
    public Renderer ren9;


    void Start()
    {
        firstPos = ren1.bounds.center;
        secondPos = ren2.bounds.center;
        thirdPos = ren3.bounds.center;
        fourthPos = ren4.bounds.center;
        fifthPos = ren5.bounds.center;
        sixthPos = ren6.bounds.center;
        seventhPos = ren7.bounds.center;
        eighthPos = ren8.bounds.center;
        ninthPos = ren9.bounds.center;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Alpha1))
    //     {
            
    //     }
    //     if (Input.GetKeyDown(KeyCode.Alpha2))
    //     {
    //         cultHuddleCamera.enabled = false;
    //         cultHallCamera.enabled = true;
    //     }
    // }
    public void Test()
    {
        Debug.Log("Test function called");
    }
    public void SceneSwitch(int sceneNum)
    {

        if (sceneNum == 1)
        {
            cam.transform.position = new Vector3(firstPos.x, firstPos.y, cam.transform.position.z);
        }
        if (sceneNum == 2)
        {
            Debug.Log("Switching to scene 2");
            cam.transform.position = new Vector3(secondPos.x, secondPos.y, cam.transform.position.z);
        }
        if (sceneNum == 3)
        {
            Debug.Log("Switching to scene 3");
            cam.transform.position = new Vector3(thirdPos.x, thirdPos.y, cam.transform.position.z);
        }
        if (sceneNum == 4)
        {
            Debug.Log("Switching to scene 4");
            cam.transform.position = new Vector3(fourthPos.x, fourthPos.y, cam.transform.position.z);
        }
        if (sceneNum == 5)
        {
            Debug.Log("Switching to scene 5");
            cam.transform.position = new Vector3(fifthPos.x, fifthPos.y, cam.transform.position.z);
        }
        if (sceneNum == 6)
        {
            Debug.Log("Switching to scene 6");
            cam.transform.position = new Vector3(sixthPos.x, sixthPos.y, cam.transform.position.z);
        }
        if (sceneNum == 7)
        {
            Debug.Log("Switching to scene 7");
            cam.transform.position = new Vector3(seventhPos.x, seventhPos.y, cam.transform.position.z);
        }
        if (sceneNum == 8)
        {
            Debug.Log("Switching to scene 8");
            cam.transform.position = new Vector3(eighthPos.x, eighthPos.y, cam.transform.position.z);
        }
        if (sceneNum == 9) 
        {
            Debug.Log("Switching to scene 9");
            cam.transform.position = new Vector3(ninthPos.x, ninthPos.y, cam.transform.position.z);
        }
    }
}
