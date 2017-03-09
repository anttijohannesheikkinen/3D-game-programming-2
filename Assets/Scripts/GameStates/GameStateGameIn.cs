using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateGameIn : GameStateBase {

    public int coinsCollected = 0;
    public int highScore = 0;
    public int extraLives = 2;

	// Use this for initialization
	protected new void Start () {
        stateName = "GameIn";
        base.Start();
    }
	
    public void PlayerRanOutOfExtraLives ()
    {
        EndGame();
    }

    private void EndGame ()
    {
        // display game over message
        GameGlobals.Instance.HighScores.SaveHighScoreData();
        GameGlobals.Instance.GameStateManager.ChangeState(GameStateBase.StateType.GameOver, "GameOver");
    }
}
