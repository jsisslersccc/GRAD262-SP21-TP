using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFall : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip playerDeath;
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
            GetComponent<AudioSource>().PlayOneShot(playerDeath);

            Animator animator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Death");


            Manager.gm.ReloadCurrentScene();
        }
    }

}