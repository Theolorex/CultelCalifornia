using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera scene1Camera;
    public Camera scene2Camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            scene1Camera.enabled = true;
            scene2Camera.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            scene1Camera.enabled = false;
            scene2Camera.enabled = true;
        }
    }
}
