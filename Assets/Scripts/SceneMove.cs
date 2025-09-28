using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cultHuddleCamera;
    public Camera cultHallCamera;
    void Start()
    {
        cultHuddleCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cultHuddleCamera.enabled = true;
            cultHallCamera.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cultHuddleCamera.enabled = false;
            cultHallCamera.enabled = true;
        }
    }

    public void sceneSwitch(int sceneNum)
    {
        if (sceneNum == 1)
        {
            cultHuddleCamera.enabled = true;
            cultHallCamera.enabled = false;
        }
        if (sceneNum == 2)
        {
            cultHuddleCamera.enabled = false;
            cultHallCamera.enabled = true;
        }
    }
}
