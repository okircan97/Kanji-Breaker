using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    
    // fields
    [SerializeField] int breakableBlocks; // this int represents the number of blocks. we serialized it for the debugging purposes. 

    // cached reference
    SceneLoader sceneloader; // this is a reference to the SceneLoader class. We'll use this to reach its methods. 

    private void Start() {
        sceneloader = FindObjectOfType<SceneLoader>(); // finds the game object with the type of SceneLoader. You can also accomplish this by
                                                       // serializing the field at 11th line and dragging the Scene Loader to it over the Unity inspector.
    }
    public void CountBlocks() {
        breakableBlocks++;
    }

    public void BlockDestroyed() {
        breakableBlocks--;
        if (breakableBlocks == 0) {
            sceneloader.LoadNextScene();
        }
    }
}
