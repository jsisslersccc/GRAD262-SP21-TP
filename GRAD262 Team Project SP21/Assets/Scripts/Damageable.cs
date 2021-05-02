using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int healthPoints = 0;

    public void takeDamage()
    {
        if (healthPoints > 0)
        {
            healthPoints -= 1;

            if (healthPoints <= 0)
            {
                DIE(); 
            }
        }
    }

    public void gainHealth()
    {
        healthPoints += 1;
    }

    void DIE()
    {
        Animator death = GetComponent<Animator>();
        death.SetTrigger("Death");
    }
}
