using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroySound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int maxHits=2;
    [SerializeField] Sprite[] hitSprites;
    //Cached ref to Level

    Level level;


    // State Variables
    [SerializeField] int timesHit; // TODO only serialized for debugging

    private void Start()
    {
        level = FindObjectOfType<Level>();
        
        
        level.countBreakableBlocks();

       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BreakBlock();

    }

    private void BreakBlock()
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);

        if (tag == "Breakable")
        {
            timesHit++;
            if (maxHits == timesHit)
            {
                
                FindObjectOfType<GameSession>().AddToScore();
                Destroy(gameObject);
                level.brickBroken();
                TriggerSparklesVFX();
            }
            else
            {
                ShowNextHitSprite();
            }
            
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
