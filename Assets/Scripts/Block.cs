using System.Collections;
using System.Collections.Generic;
using static SceneLoader;
using UnityEngine;
using System;

public class Block : MonoBehaviour {

    // configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;                 // we'll stack our sprites here, which will show the damage level.
    
    //cached reference
    Level level;

    // state variables
    [SerializeField] int timesHit;                        // it's serialized for the debug purposes.

    private void Start()
    {
        CountBreakableBlocks();
    }

    // this method is to count the breakable blocks.
    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();                // Finds the Game Object with the type of Level, and then, assign our field, level, to it.
                                                          // this thing we did above is the same as creating a serialized field as "level" and dragging 
                                                          // the game object "Field" to it. Just as we did with ball and Paddle object.
        if (tag == "Breakable")
        {
            level.CountBlocks();                          // only count the breakable blocks, so that we could go to the new level once they're destroyed.
        }
    }

    // this meethod is to destroy the  breakable blocks on collision.
    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") {
            HandleHit();                                  // call HandleHit (line 44)
        }
    }

    // when the ball collides with the blocks, this method will be invoked and will keep the track of blocks' health. 
    private void HandleHit() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;    // maxHits is equal to hitSprites' length + 1. because, if we've got 2 sprites, we must hit the block 3 times.
        if (timesHit >= maxHits) {              // if timesHit is equal to maxHits (block's health), then destroy the block  
            DestroyBlock();
        }
        else {
            showNextHitSprite();
        }
    }

    // it'll uptade the block's sprite, according to the damage it took.
    private void showNextHitSprite() {
        int spriteIndex = timesHit - 1;         // sprite's index. since the array hitSprites' index should start from 0, we make it equal to timesHit - 1.
        if (hitSprites[spriteIndex] != null) {  // if else statement is to know to throw an error if there's a missing block sprite.
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else {
            Debug.LogError("Block sprite is missing from array." + gameObject.name);  
            
        }
    }

    private void DestroyBlock() {
        PlayDestroyBlockSFX();                            // call PlayDestroyBlockSFX (its desc. is at 63th line)
        TriggerSparklesVFX();                             // call TriggerSparklesVFX  (its desc. is at 68th line)
        Destroy(gameObject);   
        level.BlockDestroyed();
        FindObjectOfType<GameStatus>().addToScore();      // we did plenty of things using only one line. without this line, we should've create a cached
                                                          // reference to GameStatus, and then, achieve its methods over that reference. just like what
                                                          // we did with the level. (12th, 15th and 18th lines)
    }

    // this method plays the voice on where the camera is
    private void PlayDestroyBlockSFX() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    // this method clones blockSparklesVFX, and returns the clone where ever the block is 
    private void TriggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);    // keeping the clones that we've created on the 45th line is not necessary. this line will delete them after a sec.
    }                             // you can see the created and destroyed sparkles objects on the inspector by checking the blocks while playing 
}
        