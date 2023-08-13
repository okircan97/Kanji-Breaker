using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    // cached reference
    SceneLoader sceneloader;

    // in the course, they load the game over screen at this part. but, i want the previous scene to load.
    private void OnTriggerEnter2D(Collider2D collision) {
        sceneloader = FindObjectOfType<SceneLoader>();       // it'll find the current sceneloader object
        sceneloader.LoadPreviousScene();                     // and will use that object to load the previous scene
        FindObjectOfType<GameStatus>().resetGame();          // it will reset the game status.
    }
}
