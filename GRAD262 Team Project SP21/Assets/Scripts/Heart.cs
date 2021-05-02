using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{

    public int heartValue = 1;
    public bool htaken = false;
    public GameObject explosion;

    // if the player touches the coin, it has not already been taken, and the player can move (not dead or victory)
    // then take the coin
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Player") && (!htaken))
        {
            // mark as taken so doesn't get taken multiple times
            htaken = true;

            // if explosion prefab is provide, then instantiate it
            if (explosion)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            other.gameObject.GetComponent<Damageable>().gainHealth();

            // destroy the coin
            DestroyObject(this.gameObject);
        }
    }

}
