using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroySound;
    [SerializeField] GameObject blockSparkleVFX;

    //Cached ref to Level

    Level level;
    
    
   

    private void Start()
    {
        level = FindObjectOfType<Level>();
        
        
        level.countBreakableBlocks();

       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        Destroy(gameObject);
        level.brickBroken();
        TriggerSparklesVFX();
        
        

       
        


    }
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
