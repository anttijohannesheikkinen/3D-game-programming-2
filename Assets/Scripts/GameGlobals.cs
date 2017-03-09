using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGlobals : MonoBehaviour {

    private static GameGlobals instance;
    public static GameGlobals Instance
    {
        get
        {

            if (instance == null)
            {
                GameObject gameGlobal = GameObject.Find("GameGlobals");
                instance = gameGlobal.AddComponent<GameGlobals>();
            }

            return instance;
        }
    }
    public GameStateManager GameStateManager;
    public HighScores HighScores;

	void Awake () {
		
        if (instance == null)
        {
            instance = this;
        }

        if (instance == this)
        {
            Init();
        }

        else
        {
            Destroy(this);
        }
	}

    private void Init ()
    {
        FindManagers();
        NullChecks();
    }

    private void Start ()
    {
        SetGameDefaults();
    }

    private void FindManagers ()
    {
        GameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
        HighScores = GameObject.Find("HighScore").GetComponent<HighScores>();
    }

    private void NullChecks ()
    {
        if (GameStateManager == null)
        {
            Debug.LogError("Couldn't find GameStateManager at GameGlobals Init." + gameObject);
        }
    }

    private void SetGameDefaults ()
    {

    }

    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
