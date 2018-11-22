using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    LevelScript level;

    private void Start()
    {
        level = FindObjectOfType<LevelScript>();
        level.CheckBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock(){
        Destroy(gameObject);
        level.BlockDestroyed();
    }

   
}
