using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;


// Modded from the save system represented by Sami Kojo at the fall of 2016 at the game programming 2d course.
public class HighScores : MonoBehaviour {

    public string CurrentPlayerName = "Anonymous";

    public List<HighScoreData> HighScoreData;
    public int CurrentHighestScore = 0;
    public int CurrentPlayerScore = 0;

    private const string SaveFileName = "HighScores.dat";
    public static string SaveFilePath
    {
        get
        {
            return Path.Combine(Application.persistentDataPath, SaveFileName);
        }
    }

    private void Awake ()
    {
        HighScoreData = LoadHighScoreData();
        CurrentHighestScore = HighScoreData[0].Score;
    }
	
    public List<HighScoreData> LoadHighScoreData ()
    {
        if (File.Exists(SaveFilePath))
        {
            Debug.Log("Save file existed");
            byte[] data = File.ReadAllBytes(SaveFilePath);
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(data);
            object saveData = bf.Deserialize(ms);
            return (List<HighScoreData>) saveData;
        }

        Debug.Log("Save file did not exist");

        List<HighScoreData> InitialJokeHighScore = new List<HighScoreData>();
        InitialJokeHighScore.Add(new HighScoreData { PlayerName = "Mike Tyson", Score = 2000 });
        InitialJokeHighScore.Add(new HighScoreData { PlayerName = "Bald Bull", Score = 300 });
        InitialJokeHighScore.Add(new HighScoreData { PlayerName = "Piston Honda", Score = 100 });
        InitialJokeHighScore.Add(new HighScoreData { PlayerName = "Von Kaiser", Score = 33 });
        InitialJokeHighScore.Add(new HighScoreData { PlayerName = "Glass Joe", Score = 12 });
        InitialJokeHighScore.Add(new HighScoreData { PlayerName = "None", Score = 0 });

        return InitialJokeHighScore;
    }

    public void SaveHighScoreData ()
    {
        AddPlayerToHighScoreList();
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms, HighScoreData);
        File.WriteAllBytes(SaveFilePath, ms.GetBuffer());
    }

    private void AddPlayerToHighScoreList ()
    {
        HighScoreData.Remove(HighScoreData[5]);
        HighScoreData.Add(new HighScoreData { PlayerName = CurrentPlayerName, Score = CurrentPlayerScore });

        SortHighScoreList();
    }

    private void SortHighScoreList ()
    {
        List<HighScoreData> list = new List<HighScoreData>(HighScoreData.Count);
        list = HighScoreData.OrderByDescending(x => x.Score).ToList();
        HighScoreData = list;
    }

    public bool DoesSaveExist()
    {
        return File.Exists(SaveFilePath);
    }
}
