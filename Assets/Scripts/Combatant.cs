using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    public int health;
    public Attack attack;

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    void Update()
    {
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }



}
