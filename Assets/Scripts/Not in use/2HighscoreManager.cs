/*using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using System.Globalization;

public class HighscoreManager : MonoBehaviour
{
    private string level2FilePath;
    private string level3FilePath;
    public List<TimeScore> level2Highscores = new List<TimeScore>();
    public List<TimeScore> level3Highscores = new List<TimeScore>();

    void Start()
    {
        level2FilePath = Path.Combine(Application.persistentDataPath, "level2_highscores.json");
        level3FilePath = Path.Combine(Application.persistentDataPath, "level3_highscores.json");

        Debug.Log("Persistent Data Path: " + Application.persistentDataPath);
        Debug.Log("Level 2 File Path: " + level2FilePath);
        Debug.Log("Level 3 File Path: " + level3FilePath);

        EnsureFileExists(level2FilePath);
        EnsureFileExists(level3FilePath);

        LoadHighscores();

        
        //string testScore = "05:44.21"; // For Testing
        //AddScoreForLevel2(testScore);
        
    }

    private void EnsureFileExists(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.Create(filePath).Dispose();
            Debug.Log($"Created new file: {filePath}");
        }
    }

    public void SaveHighscores()
    {
        SaveHighscoresForLevel(level2FilePath, level2Highscores);
        SaveHighscoresForLevel(level3FilePath, level3Highscores);
    }

    private void SaveHighscoresForLevel(string filePath, List<TimeScore> highscores)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            Debug.LogError("File path is null or empty!");
            return;
        }

        HighscoreData data = new HighscoreData { scores = highscores };
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public void LoadHighscores()
    {
        level2Highscores = LoadHighscoresForLevel(level2FilePath);
        level3Highscores = LoadHighscoresForLevel(level3FilePath);

        Debug.Log("Loaded Level 2 Highscores:");
        foreach (var score in level2Highscores)
        {
            Debug.Log(score.formattedTime);
        }

        Debug.Log("Loaded Level 3 Highscores:");
        foreach (var score in level3Highscores)
        {
            Debug.Log(score.formattedTime);
        }
    }

    private List<TimeScore> LoadHighscoresForLevel(string filePath)
    {
        List<TimeScore> loadedScores = new List<TimeScore>();
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            HighscoreData data = JsonUtility.FromJson<HighscoreData>(json);
            if (data != null && data.scores != null)
            {
                loadedScores = data.scores;
            }
        }
        return loadedScores;
    }

    
    //public void AddScoreForLevel2(string newFormattedScore)
    //{
    //    TimeScore newScore = new TimeScore(newFormattedScore);
    //    level2Highscores.Add(newScore);
    //    level2Highscores.Sort((x, y) => x.timeInSeconds.CompareTo(y.timeInSeconds));
    //    SaveHighscores();
    //}
    
}

[System.Serializable]
public class TimeScore
{
    public string formattedTime;
    public float timeInSeconds; // Store time in seconds for easier sorting

    public TimeScore(string formattedTime)
    {
        this.formattedTime = formattedTime;
        this.timeInSeconds = ParseTimeInSeconds(formattedTime);
    }

    private float ParseTimeInSeconds(string formattedTime)
    {
        TimeSpan timeSpan;
        if (TimeSpan.TryParseExact(formattedTime, @"mm\:ss\.ff", CultureInfo.InvariantCulture, out timeSpan))
        {
            return (float)timeSpan.TotalSeconds;
        }
        else
        {
            Debug.LogError($"Failed to parse time: {formattedTime}");
            return 0.0f;
        }
    }
}

[System.Serializable]
public class HighscoreData
{
    public List<TimeScore> scores;
}
*/