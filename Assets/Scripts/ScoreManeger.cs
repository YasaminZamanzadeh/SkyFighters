using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{ public int score = 0;
public int highScore;
   
    public Text scoreText;
  
    void Start()
    {
        StartCoroutine(Score());
        highScore = 0;

        
    }

  
    void Update()
    {
      scoreText.text = score.ToString();
      if (score > highScore)
      {
        highScore = score;
        Debug.Log(highScore);
      }
       }
        
    
    IEnumerator Score() {
       while(true)
       {
        yield return new WaitForSeconds(2);
        score = score + 1 ; 
       
     
       }
   }
}

  
