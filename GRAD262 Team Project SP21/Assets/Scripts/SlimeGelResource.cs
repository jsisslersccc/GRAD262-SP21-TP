using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGelResource : Resource
{
    public EnemyKnight enemy;
    public HeroKnight player;
    public float minDistanceToSlime = 5f;

    public override bool ActivateResource()
    {
        if (enemy && player && Vector2.Distance(enemy.transform.position, player.transform.position) <= minDistanceToSlime)
        {
            gameObject.SetActive(true);
            StartCoroutine(SlimeEnemy());
            return true;
        }
        return false;
    }

    IEnumerator SlimeEnemy()
    {
        gameObject.transform.position = enemy.transform.position;
        Destroy(enemy.gameObject);
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
