using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;

    public string playerName;
    public string bestPlayer = "test";
    public int bestScore = 2;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    public bool CheckScore(int score)
    {
        bool bestScoreBeaten = false;
        if (score > bestScore)
        {
            bestScoreBeaten = true;
            bestPlayer = playerName;
            bestScore = score;
            
            SaveBestScore();
        }
        return bestScoreBeaten;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.playerName = bestPlayer;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.playerName;
            bestScore = data.score;
            
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }
}
