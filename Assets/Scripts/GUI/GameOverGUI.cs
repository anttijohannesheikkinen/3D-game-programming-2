using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverGUI : GUIBase {

    private GameStateGameOver gameStateGameOver;
    public Text gameOverText;

    private new void Start ()
    {
        base.Start();
        gameStateGameOver = FindObjectOfType<GameStateGameOver>();
        gameOverText.text = "Your score: " + GameGlobals.Instance.HighScores.CurrentPlayerScore; 

        if (gameStateGameOver == null)
        {
            Debug.LogError("GameOverGUI could not find the proper game state object.");
        }
    }
}
