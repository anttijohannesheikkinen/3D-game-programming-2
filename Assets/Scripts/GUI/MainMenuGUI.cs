using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuGUI : GUIBase {

    public GameStateMainMenuIn gameStateMainMenu;
    public InputField inputField;

    private new void Start()
    {
        base.Start();
        gameStateMainMenu = FindObjectOfType<GameStateMainMenuIn>();

        if (gameStateMainMenu == null)
        {
            Debug.LogError("MainMenuGUI could not find MainMenuGameState");
        }

    }
	
    public void StartGame ()
    {
        gameStateMainMenu.OkToGoToGame();
    }

    public void ChangeName ()
    {
        GameGlobals.Instance.HighScores.CurrentPlayerName = inputField.text;
    }
}
