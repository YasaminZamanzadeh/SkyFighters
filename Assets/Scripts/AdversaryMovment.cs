using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryMovment : MonoBehaviour
{
    public Transform transform;
    public float speed = 4f;
    void Start()
    {
          transform = GetComponent<Transform>();
    }
    void Update()
    {

       transform.position -= new Vector3(0,speed * Time.deltaTime,0);
       if(transform.position.y <= -6){
            Destroy(gameObject);
  }
 }
}