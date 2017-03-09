using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateGameIn : MonoBehaviour {

    public int coinsCollected = 0;
    public int highScore = 0;
    public int extraLives = 2;

	// Use this for initialization
	void Start () {
		// Get highscore
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CoinCollected ()
    {
        coinsCollected++;
        //check highscore

        if (coinsCollected % 100 == 0)
        {
            extraLives++;
        }
    }

    public void PlayerDied ()
    {
        extraLives--;

        if (extraLives < 0)
        {
            EndGame();
        }
    }

    private void EndGame ()
    {
        // display game over message
        GameGlobals.Instance.GameStateManager.ChangeState(GameStateBase.StateType.GameOver, "GameOver");
    }

    public void LoadGame ()
    {

    }

    public void SaveGame ()
    {

    }
}
