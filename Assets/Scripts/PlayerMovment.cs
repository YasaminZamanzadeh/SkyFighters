using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
     
   

   public Transform transform;
   public float rotationSpeed = 0.5f;
   public float speed = 3.5f;
   public ScoreManeger Score;
   
    void Start()
    {

    }
    void Update()
    {
       Movment();
       Clamp(); 
    }
   void Movment()
  {
        if(Input.GetKey(KeyCode.RightArrow)){
           transform.position += new Vector3(speed * Time.deltaTime,0,0);
           transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,80),rotationSpeed * Time.deltaTime);
             }
        
        if(Input.GetKey(KeyCode.LeftArrow)){             
           transform.position -=new Vector3(speed * Time.deltaTime,0,0);
           transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,-80),rotationSpeed * Time.deltaTime);
            }
        if(transform.rotation.z !=float.MaxValue ){
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,0),rotationSpeed * Time.deltaTime);
        }

  }
  void Clamp()
  {
      Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x ,-1.64f , 1.78f);
        transform.position= pos ;
  }
  private void OnTriggerEnter2D(Collider2D collision) {
       if(collision.gameObject.tag == "Adversary"){
           Time.timeScale = 0;        
        }
        
        if(collision.gameObject.tag == "Potion"){
           Score.score += 10;
          Destroy(collision.gameObject); 
           }
      if(collision.gameObject.tag == "Poison"){
           Score.score -= 10;
           if(Score.score < 0)
          { Score.score = 0; }
          Destroy(collision.gameObject); 

     }
  }
} 
