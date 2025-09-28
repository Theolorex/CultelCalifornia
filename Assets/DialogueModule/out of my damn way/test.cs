using UnityEngine;
using TMPro;

public class TMPTestSpawner : MonoBehaviour
{
    public TMP_Text prefab;
    public Transform parent;

    void Start()
    {
        TMP_Text t = Instantiate(prefab, parent);
        t.text = "HELLO WORLD";
        t.color = Color.red;
        Debug.Log("Spawned test text at " + t.transform.position);
    }
    
}
