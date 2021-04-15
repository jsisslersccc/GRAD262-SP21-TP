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

    public Text UICoins;
    public Text UIHealth;
    void Start()
    {
        UICoins.text = "10";
        gm = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void AddPoints(int amount)
    {
        // increase score
        coins += amount;

        // update UI
        UICoins.text = "$" + coins.ToString();

    }
    public void CollectCoin(int amount)
    {
        //PlaySound(coinSFX);

        if (gm) // add the points through the game manager, if it is available
            gm.AddPoints(amount);
    }
}