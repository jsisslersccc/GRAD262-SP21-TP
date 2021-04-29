using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int healthPoints = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        if (healthPoints > 0)
        {
            healthPoints -= 1;

            if (healthPoints <= 0)
            {
                StartCoroutine(DIE()); 
            }
        }
    }

    public void gainHealth()
    {
        healthPoints += 1;
    }

    IEnumerator DIE()
    {
        Animator death = GetComponent<Animator>();

        death.SetTrigger("Death");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);

    }
}
