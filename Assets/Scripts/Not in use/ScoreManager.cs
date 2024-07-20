/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text hiScoreText;
    private float scoreCount;
    private float hiScoreCount;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("Highscore");
        }

        UpdateScoreUI();
    }

    public void UpdateScore(float elapsedTime)
    {
        scoreCount = elapsedTime;

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("Highscore", hiScoreCount);
        }

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        TimeSpan scoreTimeSpan = TimeSpan.FromSeconds(scoreCount);
        TimeSpan hiScoreTimeSpan = TimeSpan.FromSeconds(hiScoreCount);

        scoreText.text = "Score: " + scoreTimeSpan.ToString("mm':'ss'.'ff");
        hiScoreText.text = "Hi-Score: " + hiScoreTimeSpan.ToString("mm':'ss'.'ff");
    }
}
*/