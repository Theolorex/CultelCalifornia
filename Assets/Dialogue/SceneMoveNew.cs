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
    public Renderer ren1;
    public Renderer ren2;


    void Start()
    {
        firstPos = ren1.bounds.center;
        secondPos = ren2.bounds.center;
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
        Debug.Log("Switching to scene 2");
        if (sceneNum == 1)
        {
            cam.transform.position = new Vector3(firstPos.x, firstPos.y, cam.transform.position.z);
        }
        if (sceneNum == 2)
        {
            Debug.Log("Switching to scene 2");
            cam.transform.position = new Vector3(secondPos.x, secondPos.y, cam.transform.position.z);
        }
    }
}
