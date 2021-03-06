using UnityEngine;
using System.Collections;
using UnityEngine.UI; // include UI namespace so can reference UI elements
using UnityEngine.SceneManagement; // include so we can manipulate SceneManager

public class Manager : MonoBehaviour
{
    public static Manager gm;

    public int hitPoints;
    public int coins;
    public int lives;
    public int hearts;
    public Damageable playerHealth;

    public Text UICoins;
    public Text UIHealth;

    public AudioClip coinPickup;
    

    void Start()
    {
        UICoins.text = "0";
        UIHealth.text = "0";
        gm = this;
    }

    // Update is called once per frame
    void Update()
    {
        UIHealth.text = playerHealth.healthPoints.ToString();
    }
    void AddCoins(int amount)
    {
        // increase score
        coins += amount;

        // update UI
        UICoins.text = coins.ToString();

    }
    public void CollectCoin(int amount)
    {
        //PlaySound(coinSFX);

        GetComponent<AudioSource>().PlayOneShot(coinPickup);

        gm.AddCoins(amount);
    }

    public bool checkCoins(int amount)
    {
        if (coins >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void withdrawCoin(int amount)
    {
        coins -= amount;

        UICoins.text = coins.ToString();
    }

    public void LoadStartScene()
    {
        StartCoroutine(LoanStartSceneWithDelay(2f));
    }

    IEnumerator LoanStartSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<BuildOrderSceneManager>().LoadStartScene();
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoanNextSceneWithDelay(1f));
    }

    IEnumerator LoanNextSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<BuildOrderSceneManager>().LoadNextScene();
    }

    public void ReloadCurrentScene()
    {
        StartCoroutine(ReloadCurrentSceneWithDelay(2f));
    }

    IEnumerator ReloadCurrentSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<BuildOrderSceneManager>().LoadCurrentScene();
    }
}