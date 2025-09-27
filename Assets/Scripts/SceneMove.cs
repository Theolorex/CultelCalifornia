using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cultHuddleCamera;
    public Camera cultHallCamera;
    void Start()
    {
        
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
}
