/*using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTableLevel2 : MonoBehaviour
{
    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        if (entryContainer == null)
        {
            Debug.LogError("Entry Container is not assigned.");
            return;
        }
        if (entryTemplate == null)
        {
            Debug.LogError("Entry Template is not assigned.");
            return;
        }

        entryTemplate.gameObject.SetActive(false);

        // Load highscores from PlayerPrefs
        string jsonString = PlayerPrefs.GetString("highscoreTable_Level2", "{}");
        Debug.Log("Loaded Highscores JSON: " + jsonString);

        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Ensure the list is initialized
        if (highscores.highscoreEntryList == null)
        {
            highscores.highscoreEntryList = new List<HighscoreEntry>();
        }

        // Sort entry list by time
        highscores.highscoreEntryList.Sort((entry1, entry2) =>
        {
            Debug.Log("Parsing totalTime: " + entry1.totalTime + " and " + entry2.totalTime);

            TimeSpan time1;
            TimeSpan time2;

            if (TimeSpan.TryParse(entry1.totalTime, out time1) && TimeSpan.TryParse(entry2.totalTime, out time2))
            {
                return time1.CompareTo(time2);
            }
            else
            {
                // Handle parsing failure here
                Debug.LogError("Failed to parse totalTime string: " + entry1.totalTime + " or " + entry2.totalTime);
                return 0; // or handle differently as per your application's logic
            }
        });

        highscoreEntryTransformList = new List<Transform>();
        // Ensure only the top three entries are displayed
        int maxEntriesToShow = Mathf.Min(highscores.highscoreEntryList.Count, 3);
        for (int i = 0; i < maxEntriesToShow; i++)
        {
            HighscoreEntry highscoreEntry = highscores.highscoreEntryList[i];
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        Debug.Log("Highscore entries created.");
    }

    public void AddHighscoreEntry(string totalTime)
    {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { totalTime = totalTime };

        // Load saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable_Level2", "{}");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Ensure the list is initialized
        if (highscores.highscoreEntryList == null)
        {
            highscores.highscoreEntryList = new List<HighscoreEntry>();
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Sort entries by time
        highscores.highscoreEntryList.Sort((entry1, entry2) =>
        {
            TimeSpan time1;
            TimeSpan time2;

            if (TimeSpan.TryParse(entry1.totalTime, out time1) && TimeSpan.TryParse(entry2.totalTime, out time2))
            {
                return time1.CompareTo(time2);
            }
            else
            {
                // Handle parsing failure here
                Debug.LogError("Failed to parse totalTime string: " + entry1.totalTime + " or " + entry2.totalTime);
                return 0; // or handle differently as per your application's logic
            }
        });

        // Limit to top three entries
        highscores.highscoreEntryList = highscores.highscoreEntryList.Take(3).ToList();

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable_Level2", json);
        PlayerPrefs.Save();

        Debug.Log("Added Highscore Entry: " + totalTime);

        // Refresh highscore table display
        RefreshHighscoreTable();
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        string formattedTime = highscoreEntry.totalTime;
        float templateHeight = 100f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("PositionText1").GetComponent<Text>().text = rankString;

        int hours = highscoreEntry.GetHours();
        int minutes = highscoreEntry.GetMinutes();
        int seconds = highscoreEntry.GetSeconds();

        string totalTime = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);

        entryTransform.Find("ElapsedText1").GetComponent<Text>().text = formattedTime;

        transformList.Add(entryTransform);
    }

    private void RefreshHighscoreTable()
    {
        // Clear existing entries
        foreach (Transform child in entryContainer)
        {
            Destroy(child.gameObject);
        }

        // Reload and display highscore entries
        LoadHighscores();
    }

    private void LoadHighscores()
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable_Level2", "{}");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores != null && highscores.highscoreEntryList != null)
        {
            Debug.Log("Loaded " + highscores.highscoreEntryList.Count + " highscore entries.");

            highscores.highscoreEntryList.Sort((entry1, entry2) =>
            {
                TimeSpan time1;
                TimeSpan time2;

                if (TimeSpan.TryParse(entry1.totalTime, out time1) && TimeSpan.TryParse(entry2.totalTime, out time2))
                {
                    return time1.CompareTo(time2);
                }
                else
                {
                    Debug.LogError("Failed to parse totalTime string: " + entry1.totalTime + " or " + entry2.totalTime);
                    return 0;
                }
            });

            highscoreEntryTransformList.Clear();

            int maxEntriesToShow = Mathf.Min(highscores.highscoreEntryList.Count, 3);
            for (int i = 0; i < maxEntriesToShow; i++)
            {
                HighscoreEntry highscoreEntry = highscores.highscoreEntryList[i];
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
        }
        else
        {
            Debug.LogWarning("No highscores found for Level 2.");
        }
    }




    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    // Represents a single highscore entry
    [System.Serializable]
    private class HighscoreEntry
    {
        public string totalTime;

        public int GetHours()
        {
            if (TimeSpan.TryParse(totalTime, out TimeSpan timeSpan))
            {
                return timeSpan.Hours;
            }
            return 0;
        }

        public int GetMinutes()
        {
            if (TimeSpan.TryParse(totalTime, out TimeSpan timeSpan))
            {
                return timeSpan.Minutes;
            }
            return 0;
        }

        public int GetSeconds()
        {
            if (TimeSpan.TryParse(totalTime, out TimeSpan timeSpan))
            {
                return timeSpan.Seconds;
            }
            return 0;
        }
    }
}
*/