using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
   public Transform transform;
   public float rotationSpeed = 0.5f;
   public float speed = 3.5f;
   public ScoreManeger Score;
   public GameObject GameOverPanel;
   public AudioSource PoisonSound;
   public AudioSource potionSound;
   public AudioSource GameOverSound;
   public GameObject bulletprefabs;
   public float bulletspeed;
   
    void Start()
    {
      GameOverPanel.SetActive(false);
      Time.timeScale = 1;
    }
    void Update()
    {
       Movment();
       Shooting();
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
  void Shooting(){
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bullet = Instantiate(bulletprefabs);
            bullet.transform.SetParent(transform.parent);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletspeed , transform.position.z);
            Destroy(bullet, 5);
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
           GameOverPanel.SetActive(true);  
           GameOverSound.Play();
        }
        
        if(collision.gameObject.tag == "Potion"){
         potionSound.Play();
           Score.score += 10;
          Destroy(collision.gameObject); 
           }
      if(collision.gameObject.tag == "Poison"){
           PoisonSound.Play();
           Score.score -= 10;
           if(Score.score < 0)
          { Score.score = 0; }
          Destroy(collision.gameObject); 

     }
  }
} 
