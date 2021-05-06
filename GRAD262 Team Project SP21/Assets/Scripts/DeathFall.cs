using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Animator animator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Death");
            Manager.gm.ReloadCurrentScene();
        }
    }

}