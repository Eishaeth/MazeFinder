/*using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HighscoreDisplay : MonoBehaviour
{
    public HighscoreManager highscoreManager;

    // Level 2 Text Objects
    public Text level2PositionText1;
    public Text level2PositionText2;
    public Text level2PositionText3;
    public Text elapsedText1;  // For displaying the top 1 score for level 2
    public Text elapsedText2;  // For displaying the top 2 score for level 2
    public Text elapsedText3;  // For displaying the top 3 score for level 2

    // Level 3 Text Objects
    public Text level3PositionText1;
    public Text level3PositionText2;
    public Text level3PositionText3;
    public Text elapsedText4;  // For displaying the top 1 score for level 3
    public Text elapsedText5;  // For displaying the top 2 score for level 3
    public Text elapsedText6;  // For displaying the top 3 score for level 3

    void Start()
    {
        highscoreManager.LoadHighscores();
        DisplayHighscores();
    }

    void DisplayHighscores()
    {
        var level2Top3 = highscoreManager.level2Highscores.OrderByDescending(score => score.timeInSeconds).Take(3).ToList();
        var level3Top3 = highscoreManager.level3Highscores.OrderByDescending(score => score.timeInSeconds).Take(3).ToList();

        // Clear existing text
        level2PositionText1.text = "";
        level2PositionText2.text = "";
        level2PositionText3.text = "";
        level3PositionText1.text = "";
        level3PositionText2.text = "";
        level3PositionText3.text = "";
        elapsedText1.text = "";
        elapsedText2.text = "";
        elapsedText3.text = "";
        elapsedText4.text = "";
        elapsedText5.text = "";
        elapsedText6.text = "";

        // Display Level 2 Highscores
        for (int i = 0; i < level2Top3.Count; i++)
        {
            if (i == 0)
            {
                level2PositionText1.text = "1ST";
                elapsedText1.text = level2Top3[i].formattedTime;
            }
            else if (i == 1)
            {
                level2PositionText2.text = "2ND";
                elapsedText2.text = level2Top3[i].formattedTime;
            }
            else if (i == 2)
            {
                level2PositionText3.text = "3RD";
                elapsedText3.text = level2Top3[i].formattedTime;
            }
        }

        // Display Level 3 Highscores
        for (int i = 0; i < level3Top3.Count; i++)
        {
            if (i == 0)
            {
                level3PositionText1.text = "1ST";
                elapsedText4.text = level3Top3[i].formattedTime;
            }
            else if (i == 1)
            {
                level3PositionText2.text = "2ND";
                elapsedText5.text = level3Top3[i].formattedTime;
            }
            else if (i == 2)
            {
                level3PositionText3.text = "3RD";
                elapsedText6.text = level3Top3[i].formattedTime;
            }
        }

    }
}
*/