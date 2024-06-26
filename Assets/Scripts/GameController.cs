using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject HUDScale, gameOverPanel, TimerHUD;
    public Text timeCounter, FinalTimeText;
    public bool gamePlaying { get; private set; }

    private float startTime, elapsedTime;
    TimeSpan timePlaying;

    private void Start()
    {
         BeginGame();
    }

    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if(gamePlaying)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
        }
    }
    void SetTextAlpha(Text textComponent, float alphaValue)
    {
        Color textColor = textComponent.color;
        textColor.a = alphaValue;
        textComponent.color = textColor;
    }
    public void EndGame()
    {
        gamePlaying = false;
        Debug.Log("EndGame method called");
        Invoke("ShowGameOverScreen", 1.25f);
        SetTextAlpha(timeCounter, 0f);
    }
    private void ShowGameOverScreen()
    {
        Debug.Log("ShowGameOverScreen method called");
        gameOverPanel.SetActive(true);
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
        gameOverPanel.transform.Find("FinalTimeText").GetComponent<Text>().text = timePlayingStr;
        Debug.Log("gameOverPanel should now be active");
    }
}