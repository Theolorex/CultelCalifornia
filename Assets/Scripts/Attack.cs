using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public String attackName;
    public int damage;

    // Start is called before the first frame update
    public void doAttack(Combatant attacked)
    {
        attacked.takeDamage(damage);

    }
}
