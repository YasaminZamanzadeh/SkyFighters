using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
   public float speed = 3.5f;
   public Transform transform;
    void Start()
    {

    }
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
           transform.position += new Vector3(speed * Time.deltaTime,0,0);
             }

         if(Input.GetKey(KeyCode.LeftArrow)){             
           transform.position -=new Vector3(speed * Time.deltaTime,0,0);
            }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x , -1.45f , 1.6f);
        transform.position= pos ;
  }
}