using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public int coinValue = 1;
	public bool taken = false;
	public GameObject explosion;

	// if the player touches the coin, it has not already been taken, and the player can move (not dead or victory)
	// then take the coin
	void OnTriggerEnter2D (Collider2D other)
	{

        

        
		if ((other.tag == "Player" ) && (!taken))
		{
			// mark as taken so doesn't get taken multiple times
			taken=true;

            

            // if explosion prefab is provide, then instantiate it
            if (explosion)
			{
				Instantiate(explosion,transform.position,transform.rotation);
			}

			// do the player collect coin thing
			Manager.gm.CollectCoin(coinValue);
            

			// destroy the coin
			Object.Destroy(gameObject);
		}
	}

}
