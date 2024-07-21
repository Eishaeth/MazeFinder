using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject HUDScale, gameOverPanel, TimerHUD;
    public Text timeCounter, FinalTimeText, FinalScoreText;
    public bool gamePlaying { get; private set; }

    public AudioSource audioSourcesToMuteOne, gameOverAudioSource;

    private float startTime, elapsedTime;
    private TimeSpan timePlaying;

    //Score
    int score;
    public Text scoreText;
    public float timeCut = 1f;
    public float maxScore = 1000000f;

    public float timeReductionPerItem = 5.0f; // Adjust this value as needed
    private float timeDecrementRate = 555.56f; //for score

    private void Start()
    {
        BeginGame();
    }

    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("gameOverPanel is not assigned in BeginGame");
        }
    }

    private void Update()
    {
        if (gamePlaying)
        {
            elapsedTime = Time.time - startTime;

            timeCut += Time.deltaTime * timeDecrementRate;


            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            //Score
            score = Mathf.RoundToInt(maxScore - timeCut);
            scoreText.text = "Score: " + score.ToString();

            if (score < 0)
            {
                score = 0;
            }

            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            if (timeCounter != null)
            {
                timeCounter.text = timePlayingStr;
            }
            else
            {
                Debug.LogError("timeCounter is not assigned in Update");
            }


        }
    }

    public void CollectItem()
    {
        if (gamePlaying)
        {
            elapsedTime -= timeReductionPerItem; // Subtract time reduction
            elapsedTime = Mathf.Clamp(elapsedTime, 0.0f, float.MaxValue); // Ensure timer doesn't go negative
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timeCounter.text = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
        }
    }

    void SetTextAlpha(Text textComponent, float alphaValue)
    {
        if (textComponent != null)
        {
            Color textColor = textComponent.color;
            textColor.a = alphaValue;
            textComponent.color = textColor;
        }
        else
        {
            Debug.LogError("Text component is not assigned in SetTextAlpha");
        }
    }

    public void EndGame()
    {
        gamePlaying = false;
        Debug.Log("EndGame method called");
        Invoke("ShowGameOverScreen", 1.25f);
        SetTextAlpha(timeCounter, 0f);
        SetTextAlpha(scoreText, 0f);

        // Save the highscore
        SaveHighscore(score);

        if (audioSourcesToMuteOne != null)
        {
            audioSourcesToMuteOne.mute = true;
        }
        else
        {
            Debug.LogError("audioSourcesToMuteOne is not assigned in EndGame");
        }

        if (gameOverAudioSource != null)
        {
            Invoke("UnmuteGameOverAudioSource", 1.25f);
            gameOverAudioSource.Play();
        }
        else
        {
            Debug.LogError("gameOverAudioSource is not assigned in EndGame");
        }
    }

    private void ShowGameOverScreen()
    {
        Debug.Log("ShowGameOverScreen method called");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            string endScore = "Score: " + score.ToString();
            if (FinalTimeText != null)
            {
                FinalTimeText.text = timePlayingStr;
            }
            else
            {
                Debug.LogError("FinalTimeText is not assigned in ShowGameOverScreen");
            }
            if (FinalScoreText != null)
            {
                FinalScoreText.text = endScore;
            }
            else
            {
                Debug.LogError("FinalScoreText is not assigned in ShowGameOverScreen");
            }
            Debug.Log("gameOverPanel should now be active");
        }
        else
        {
            Debug.LogError("gameOverPanel is not assigned in ShowGameOverScreen");
        }
    }

    private void UnmuteAudioSource(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.mute = false;
        }
        else
        {
            Debug.LogError("AudioSource is not assigned in UnmuteAudioSource");
        }
    }

    private void UnmuteGameOverAudioSource()
    {
        UnmuteAudioSource(gameOverAudioSource);
    }

    public void SaveHighscore(float score)
    {
        // Get the current scene
        string sceneName = SceneManager.GetActiveScene().name;

        // Determine the highscore key based on the scene name
        string highscoreKey = "HighscoreDefault";
        if (sceneName == "Level 2 Palace PC End" || sceneName == "Level 2 VR Complete")
        {
            highscoreKey = "HighscoreLevel2";
        }
        else if (sceneName == "Level 3 PC End" || sceneName == "Level 3 VR Complete")
        {
            highscoreKey = "HighscoreLevel3";
        }

        // Get the current highscore for the determined key
        float currentHighscore = PlayerPrefs.GetFloat(highscoreKey, 0.0f); // Default to 0 if no highscore is saved

        // Log the current highscore before updating
        Debug.Log("Current Highscore for " + highscoreKey + ": " + currentHighscore);

        // Update the highscore if the current score is higher
        if (score > currentHighscore)
        {
            PlayerPrefs.SetFloat(highscoreKey, score);
            PlayerPrefs.Save();

            // Log the new highscore
            Debug.Log("New Highscore for " + highscoreKey + ": " + score);
        }
        else
        {
            // Log that the score did not update
            Debug.Log("Score of " + score + " did not exceed the current highscore of " + currentHighscore + " for " + highscoreKey);
        }
    }
}
