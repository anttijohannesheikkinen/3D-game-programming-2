using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int coinsCollected = 0;
    public int currentHighScore = 0;

    public PlayerManager playerManager;

    private void Awake ()
    {
        playerManager = FindObjectOfType<PlayerManager>();

        if (playerManager == null)
        {
            Debug.LogError("Score couldn't find PlayerManager.");
        }
    }

    public void CoinCollected()
    {
        coinsCollected++;
        

        if (coinsCollected < currentHighScore)
        {
            currentHighScore = coinsCollected;
        }

        if (coinsCollected % 100 == 0)
        {
            playerManager.extraLives++;
        }
    }
}
