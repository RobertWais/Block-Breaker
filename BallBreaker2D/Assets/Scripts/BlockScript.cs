using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    //Reference
    LevelScript level;

    //Config Params
    [SerializeField] GameObject sparkleEffect;
    [SerializeField] Sprite[] hitSprites;

    //state variables
    [SerializeField] int timesHit;


    private void Start()
    {
        level = FindObjectOfType<LevelScript>();
        if(tag=="Breakable"){
            level.CheckBreakableBlocks();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(tag == "Breakable"){
            int maxHits = hitSprites.Length + 1;
            //int max hits = array.length +1
            timesHit++;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }else{
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
       
        int hitSpriteNumber = timesHit - 1;
        if (hitSprites[hitSpriteNumber] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[hitSpriteNumber];
        }else{
            Debug.LogError("No Image");
        }

    }

    private void DestroyBlock(){
        TriggerSparklesVFX();
        FindObjectOfType<GameStatus>().AddToScore();
        Destroy(gameObject);
        level.BlockDestroyed();
    }

    private void TriggerSparklesVFX(){
        GameObject sparkles = Instantiate(sparkleEffect, transform.position,transform.rotation);
        Destroy(sparkles, 1f);
    }
}
