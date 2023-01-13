using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversarySpawner : MonoBehaviour
{
    public GameObject[] Adversaries;
    void Start()
    {
        StartCoroutine(AdversarySpawn());
    }


    void Update()
    {

    }
     void Adversary()
    {
        int rand = Random.Range(0,Adversaries.Length);
        float rndPosition = Random.Range(-1.64f , 1.78f);
         Instantiate(Adversaries[rand],new Vector3(rndPosition,transform.position.y,transform.position.z),Quaternion.Euler(0,0,0));       

    }
    IEnumerator AdversarySpawn(){
        while(true){   
        yield return new WaitForSeconds(5);
        Adversary();
        }

    }
}
