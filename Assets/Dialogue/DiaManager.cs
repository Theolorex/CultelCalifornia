using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiaManager : MonoBehaviour
{
    public TextMeshPro tankText;
    public TextMeshPro wizardText;
    public TextMeshPro bardText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            show();
        }
    }

    void show()
    {
        tankText.text = "I am a tank that does tank things.";
        wizardText.text = "I am a wizard that does wizard things.";
        bardText.text = "I am a bard that does bard things.";
    }
}
