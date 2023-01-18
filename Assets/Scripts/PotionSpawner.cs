using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
     public GameObject [] potionsPrefabs;
    void Start()
    {
        StartCoroutine(potionSpawner());
    }

    void Update()
    {
        
    }

    void potionSpawn(){
        int value = Random.Range(0,potionsPrefabs.Length);
        float rand = Random.Range(-1.64f , 1.78f);
        Instantiate(potionsPrefabs[value], new Vector3(rand,transform.position.y,transform.position.z),Quaternion.identity);

    }
    IEnumerator potionSpawner() {
        while(true)
        {
            int time = Random.Range(0,20);
            yield return new WaitForSeconds(2);
            potionSpawn();
        }
    }
}
