using System;
using UnityEngine;
using UnityEngine.UI;

public class GUIBase : MonoBehaviour {

    public Text highScoreText;


    protected void Start ()
    {
        UpdateHighScoreTable();
    }

    public void UpdateHighScoreTable()
    {
        highScoreText.text = "TOP 5: " + Environment.NewLine + 
                             "1. " + GameGlobals.Instance.HighScores.HighScoreData[0].PlayerName + "  " + GameGlobals.Instance.HighScores.HighScoreData[0].Score + Environment.NewLine +
                             "2. " + GameGlobals.Instance.HighScores.HighScoreData[1].PlayerName + "  " + GameGlobals.Instance.HighScores.HighScoreData[1].Score + Environment.NewLine +
                             "3. " + GameGlobals.Instance.HighScores.HighScoreData[2].PlayerName + "  " + GameGlobals.Instance.HighScores.HighScoreData[2].Score + Environment.NewLine +
                             "4. " + GameGlobals.Instance.HighScores.HighScoreData[3].PlayerName + "  " + GameGlobals.Instance.HighScores.HighScoreData[3].Score  + Environment.NewLine +
                             "5. " + GameGlobals.Instance.HighScores.HighScoreData[4].PlayerName + "  " + GameGlobals.Instance.HighScores.HighScoreData[4].Score;
    }

    public void GoToMainMenu()
    {
        Debug.Log("Transition via GUI to MainMenu.");
        GameGlobals.Instance.GameStateManager.ChangeState(GameStateBase.StateType.MainMenuIn, "MainMenu");
    }

    public void QuitGame()
    {
        GameGlobals.Instance.ExitGame();
    }
}
