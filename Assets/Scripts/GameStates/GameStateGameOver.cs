using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateGameOver : GameStateBase {

	// Use this for initialization
	protected new void Start () {
        stateName = "GameOver";
        base.Start();
    }
	
	protected void GoToMainMenu ()
    {
        Debug.Log("Game Over script told to transition to Main Menu");
        gameStateManager.ChangeState(StateType.MainMenuIn, "MainMenu");
    }
}
