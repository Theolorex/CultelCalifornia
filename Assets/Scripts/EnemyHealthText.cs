using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthText : MonoBehaviour
{
    // Start is called before the first frame update

    public Combatant enemy;
    public TextMeshPro healthText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + enemy.health.ToString();
    }
}
