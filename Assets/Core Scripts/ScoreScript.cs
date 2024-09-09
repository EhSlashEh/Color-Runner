using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    
    public static int score;
    public static int highscore;

    void Start()
    {
        //Set score to 0 at start
        score = 0;

        //Get highscore int from player pref
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
    }
    
    void Update()
    {
        //Have score text be current score
        scoreText.text = "Score: " + score.ToString();

        //Check score is bigger than current score; make bigger one new highscore
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
}
