using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMid : MonoBehaviour
{
    public Renderer ren;
    public Camera targetCamera;
    // Start is called before the first frame update
    void Start()
    {
        targetCamera.enabled = true;
        Vector3 mid = ren.bounds.center;
        targetCamera.transform.position = new Vector3(mid.x, mid.y, targetCamera.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
