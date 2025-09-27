using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthoThing: MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer sr;
    public Camera targetCamera;
    void Start()
    {
        float orthoSize = sr.bounds.size.x * Screen.height / Screen.width * 0.5f;
        Camera.main.orthographicSize = orthoSize;

    }
    

    // Update is called once per frame
    void Update()
    {

    }

    // public void getSpriteInCamera(GameObject sprite)
    // {
    //     Renderer rend = sprite.GetComponent<Renderer>();
    //     Bounds bounds = rend.bounds;
    //     Vector3 objectSizes = bounds.size;
    //     float objectSize = Mathf.Max(objectSizes.x, objectSizes.y, objectSizes.z);
    //     float distance = objectSize / (2.0f * Mathf.Tan(0.5f * targetCamera.fieldOfView * Mathf.Deg2Rad));


    // }
}
