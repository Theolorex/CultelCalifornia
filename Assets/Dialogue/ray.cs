using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ray : MonoBehaviour
{
    // Start is called before the first frame update
    // public SceneMoveNew sm;
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
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("Casting ray");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit " + hit.transform.name);
                if (hit.transform.tag == "Tank")
                {
                    Debug.Log("Hit a tank");
                    TestFunc();
                    Switch(2);
                    // Debug.Log("Switched to scene 2");

                }
                if (hit.transform.tag == "wizard")
                {
                    Debug.Log("Hit a wizard");
                }
                if (hit.transform.tag == "bard")
                {
                    Debug.Log("Hit a bard");
                }
            }
        }
    }
    void TestFunc()
    {
        Debug.Log("Test function called");
    }
    void Switch(int sceneNum)
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
