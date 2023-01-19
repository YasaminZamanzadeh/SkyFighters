using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class ScoreManeger : MonoBehaviour
{ 
    public int score = 0;
    public Text scoreText;
    public Text HighScoreText;
    public Text lastScoreText;
    public int highScore;
    public static int lastScore = 0;

    void Start()
    {
        StartCoroutine(Score());
        // StartCoroutine(Reload());
        highScore = PlayerPrefs.GetInt("high_score" , 0);
        lastScore = PlayerPrefs.GetInt("last_score" , 0);
        HighScoreText.text = "High Score: " + highScore.ToString();
        lastScoreText.text = "Last Score: " + lastScore.ToString();
    }

    void Update()
    {
        scoreText.text = score.ToString();
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("high_score", highScore);
        
        }
    }

    IEnumerator Score() {
        while(true){
        yield return new WaitForSeconds(2);
        score = score + 1;
        lastScore = score;
        PlayerPrefs.SetInt("last_score", lastScore);
        }
    }

     IEnumerator Reload() {
      
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Game");

        }
    }
