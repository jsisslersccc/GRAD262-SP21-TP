using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGateway : MonoBehaviour
{
    public bool unlocked = false;

    /*
    // TESTING ONLY!
    void OnCollisionEnter2D(Collision2D collision)
    {
        Unlock();
    }
    */

    public void Unlock()
    {
        unlocked = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (unlocked)
            Manager.gm.LoadNextScene();
    }
}
