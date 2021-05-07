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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (unlocked)
            Manager.gm.LoadNextScene();
    }
}
