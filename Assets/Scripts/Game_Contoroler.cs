using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Contoroler : MonoBehaviour
{
    public Text highScoreText;
    public Text scoreText;
    public int highScore;
    public int score;
    public ScoreManeger score_manager;
    public GameObject gamePausePanel;
    public GameObject gamePauseButton;


    // Start is called before the first frame update
    void Start()
    {
       gamePausePanel.SetActive(false);
       gamePauseButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("high_score");
        score = score_manager.score;
        highScoreText . text = "High Score :"+ highScore.ToString();
        scoreText . text = "Your Score :"+ score.ToString();
    }
    public void Restart() {
        SceneManager.LoadScene("Game");

    }
    public void PauseGame(){
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
        gamePauseButton.SetActive(false);
    }
    public void ResumeGame(){
        Time.timeScale = 1;
        gamePausePanel.SetActive(false);
        gamePauseButton.SetActive(true);
    }
  
}
