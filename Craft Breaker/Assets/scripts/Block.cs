using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroySound;

    //Cached ref to Level

    Level level;
    
   

    private void Start()
    {
        level = FindObjectOfType<Level>();

        level.countBreakableBlocks();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        Destroy(gameObject);
        level.brickBroken();
        level.scoreIncrease();
        


    }
}
