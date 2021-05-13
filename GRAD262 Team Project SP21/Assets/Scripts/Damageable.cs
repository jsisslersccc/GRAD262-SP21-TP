using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int healthPoints = 0;

    public AudioClip healthPickup;
    public AudioClip playerDeath;

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

        GetComponent<AudioSource>().PlayOneShot(healthPickup);
    }

    void DIE()
    {
        Animator death = GetComponent<Animator>();
        death.SetTrigger("Death");

        GetComponent<AudioSource>().PlayOneShot(playerDeath);

        if (tag.Equals("Player"))
        {
            Manager.gm.LoadStartScene();
        }
    }
}
