using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int cost = 1;

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
        if (Manager.gm.checkCoins(cost))
        {
            if (collision.CompareTag("Player"))
            {
                ResourceManager.S.PurchaseResource(this);
                Manager.gm.withdrawCoin(cost);
            }
        }
    }

    virtual public bool ActivateResource()
    {
        return false;
    } 
}
