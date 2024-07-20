using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Text highscoreText1;
    public Text highscoreText2;

    public void Start()
    {
        DisplayHighscore();
    }

    public void DisplayHighscore()
    {
        float highscoreLevel2 = PlayerPrefs.GetFloat("HighscoreLevel2", 0.0f);
        float highscoreLevel3 = PlayerPrefs.GetFloat("HighscoreLevel3", 0.0f);

        int roundedHighscoreLevel2 = Mathf.RoundToInt(highscoreLevel2);
        int roundedHighscoreLevel3 = Mathf.RoundToInt(highscoreLevel3);

        if (highscoreText1 != null)
        {
            highscoreText1.text = roundedHighscoreLevel2.ToString();
        }
        else
        {
            Debug.LogError("highscoreText1 is not assigned in DisplayHighscore");
        }

        if (highscoreText2 != null)
        {
            highscoreText2.text = roundedHighscoreLevel3.ToString();
        }
        else
        {
            Debug.LogError("highscoreText2 is not assigned in DisplayHighscore");
        }

    }
}
