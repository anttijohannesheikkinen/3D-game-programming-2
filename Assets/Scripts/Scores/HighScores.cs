using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour {

    public string CurrentPlayerName = "Anonymous";

    public List<HighScoreData> HighScoreData;
    public int CurrenHighestScore = 0;
    public int CurrentPlayerScore = 0;

	private void Awake ()
    {
        HighScoreData = new List<HighScoreData>();
        HighScoreData.Add(new HighScoreData { PlayerName = "Antti", Score = 1300 });
        HighScoreData.Add(new HighScoreData { PlayerName = "Antti2", Score = 2200 });
        HighScoreData.Add(new HighScoreData { PlayerName = "Jaajoo", Score = 3300 });
        HighScoreData.Add(new HighScoreData { PlayerName = "JeeJeeJee", Score = 100 });
        HighScoreData.Add(new HighScoreData { PlayerName = "Woohoo", Score = 23 });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
