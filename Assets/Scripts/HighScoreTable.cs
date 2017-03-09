using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreTable : MonoBehaviour {

    public List<HighScoreData> HighScoreList;

    private void Awake ()
    {
        HighScoreList = new List<HighScoreData>();
        HighScoreList.Add(new HighScoreData { Id = 0, PlayerName = "FuckYou", Score = 1000});
        HighScoreList.Add(new HighScoreData { Id = 1, PlayerName = "FuckMe", Score = 1001 });
        HighScoreList.Add(new HighScoreData { Id = 2, PlayerName = "FuckThem", Score = 1002 });
        HighScoreList.Add(new HighScoreData { Id = 3, PlayerName = "FuckUsAll", Score = 1003 });
    }
}
