using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGelResource : Resource
{
    public float minDistanceToSlime = 5f;

    public override bool ActivateResource()
    {
        HeroKnight player = FindObjectOfType<HeroKnight>();
        EnemyKnight enemy = FindEnemyClosestToPlayer();

        if (enemy && player && Vector2.Distance(enemy.transform.position, player.transform.position) <= minDistanceToSlime)
        {
            gameObject.SetActive(true);
            StartCoroutine(SlimeEnemy(enemy));
            return true;
        }

        return false;
    }

    IEnumerator SlimeEnemy(EnemyKnight enemy)
    {
        gameObject.transform.position = enemy.transform.position;
        Destroy(enemy.gameObject);
        GetComponent<Animator>().SetTrigger("SlimeEnemy");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
