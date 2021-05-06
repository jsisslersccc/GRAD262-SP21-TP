using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinVictory : MonoBehaviour
{

    public int coinValue = 1000;
    public bool taken = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter OnTriggerEnter2D");
        if (collision.gameObject.CompareTag("Player"))
        {
            //Animator animator = collision.gameObject.GetComponent<Animator>();
            //animator.SetTrigger("Death");

            Manager.gm.CollectCoin(coinValue);

            Object.Destroy(gameObject);

            Manager.gm.ReloadCurrentScene();
        }
    }
}
