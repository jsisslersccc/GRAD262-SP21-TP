using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildOrderSceneManager : MonoBehaviour
{
    public bool splashScreen = false;
    public float splashScreenPause = 5f;

    void Start()
    {
        if (splashScreen)
            Invoke("LoadNextScene", splashScreenPause);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        int currentActiveScene = SceneManager.GetActiveScene().buildIndex;
        if (currentActiveScene + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentActiveScene + 1);
        }
        else
        {
            Debug.LogError("No next scene!");
        }
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

