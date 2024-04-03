using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite blueberrySprite;

    public void SetSprite(bool isApple)
    {
        spriteRenderer.sprite = isApple ? appleSprite : blueberrySprite;
    }

    public void Destory()
    {
        GameObject.Destroy(gameObject);
    }
}

  

 
