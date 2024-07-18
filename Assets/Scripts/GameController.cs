using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject HUDScale, gameOverPanel, TimerHUD;
    public Text timeCounter, FinalTimeText;
    public bool gamePlaying { get; private set; }

    public AudioSource audioSourcesToMuteOne, audioSourcesToMuteTwo, gameOverAudioSource;

    private float startTime, elapsedTime;
    private TimeSpan timePlaying;

    public float timeReductionPerItem = 5.0f; // Adjust this value as needed
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
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

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

        if (audioSourcesToMuteOne != null)
        {
            audioSourcesToMuteOne.mute = true;
        }
        else
        {
            Debug.LogError("audioSourcesToMuteOne is not assigned in EndGame");
        }

        if (audioSourcesToMuteTwo != null)
        {
            audioSourcesToMuteTwo.mute = true;
        }
        else
        {
            Debug.LogError("audioSourcesToMuteTwo is not assigned in EndGame");
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
            if (FinalTimeText != null)
            {
                FinalTimeText.text = timePlayingStr;
            }
            else
            {
                Debug.LogError("FinalTimeText is not assigned in ShowGameOverScreen");
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
}
