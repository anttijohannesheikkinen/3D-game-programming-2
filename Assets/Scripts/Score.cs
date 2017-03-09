using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int coinsCollected = 0;
    public float score = 0;
    public float currentHighScore = 0;
    public int currentMultiplier = 1;
    public int coinsToGetToRaiseMultiplier = 10;
    public float timerStartTime;
    public float GUIScoreUpdateTimerLength = 0.16f;

    public Text GUIScoreText;
    public Text GUIMultiplierText;
    public Text GUICurrentHighestScoreText;

    public PlayerManager playerManager;

    private FloorManager floorManager;

    private void Awake ()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        floorManager = FindObjectOfType<FloorManager>();

        if (playerManager == null)
        {
            Debug.LogError("Score couldn't find PlayerManager.");
        }

        if (floorManager == null)
        {
            Debug.LogError("Score couldn't find FloorManager.");
        }
    }

    private void Start ()
    {
        UpdateScoreGUI();
        UpdateMultiplierGUI();
        currentHighScore = GameGlobals.Instance.HighScores.CurrentHighestScore;
        UpdateCurrentHighestScore();
    }

    private void Update ()
    {
        if (!playerManager.dead)
        {
            score = score + (Time.deltaTime * floorManager.Speed * currentMultiplier);
            GameGlobals.Instance.HighScores.CurrentPlayerScore = (int)score;
        }

        if (Time.time > timerStartTime + GUIScoreUpdateTimerLength)
        {
            UpdateScoreGUI();
        }
    }

    private void UpdateScoreGUI ()
    {
        GUIScoreText.text = "SCORE: " + (int) score;
        timerStartTime = Time.time;

        if (score > currentHighScore)
        {
            currentHighScore = score;
            UpdateCurrentHighestScore();
        }
    }

    private void UpdateMultiplierGUI ()
    {
        GUIMultiplierText.text = "Multiplier: " + currentMultiplier;
    }

    private void UpdateCurrentHighestScore()
    {
        GameGlobals.Instance.HighScores.CurrentHighestScore = (int) score;
        GUICurrentHighestScoreText.text = "Current High Score: " + (int) currentHighScore;
    }

    public void CoinCollected()
    {
        coinsCollected++;
        coinsToGetToRaiseMultiplier--;
        
        if (coinsToGetToRaiseMultiplier <= 0)
        {
            currentMultiplier++;
            coinsToGetToRaiseMultiplier = 10;
            UpdateMultiplierGUI();
        }
    }
}
