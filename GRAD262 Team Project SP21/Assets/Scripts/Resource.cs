using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    public int cost = 1;
    public Text descriptionText;
    public string description = "Thouest instruction have not!";

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

    public static EnemyKnight FindEnemyClosestToPlayer()
    {
        HeroKnight player = FindObjectOfType<HeroKnight>();
        EnemyKnight[] enemies = FindObjectsOfType<EnemyKnight>();
        EnemyKnight closest = null;
        float minDistance = 0;

        foreach (EnemyKnight enemy in enemies) {
            float distance = Vector2.Distance(player.transform.position, enemy.transform.position);

            if (closest == null || distance < minDistance)
            {
                closest = enemy;
                minDistance = distance;
            }
        }

        return closest;
    }

    public static SceneGateway FindSceneGatewayClosestToPlayer()
    {
        HeroKnight player = FindObjectOfType<HeroKnight>();
        SceneGateway[] Gateways = FindObjectsOfType<SceneGateway>();
        SceneGateway closest = null;
        float minDistance = 0;

        foreach (SceneGateway Gateway in Gateways)
        {
            float distance = Vector2.Distance(player.transform.position, Gateway.transform.position);

            if (closest == null || distance < minDistance)
            {
                closest = Gateway;
                minDistance = distance;
            }
        }

        return closest;
    }

     void OnMouseOver()
    {
        descriptionText.text = description;
    }

    void OnMouseExit()
    {
        descriptionText.text = "";
    }
}
