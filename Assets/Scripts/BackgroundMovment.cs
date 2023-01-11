using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovment : MonoBehaviour
{
    public Renderer meshRenderer;
   public float speed = 0.3f;
    void Start()
    {

    }
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(0,speed * Time.deltaTime);

    }
}
