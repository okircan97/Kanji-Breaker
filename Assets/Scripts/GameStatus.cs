using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {
    
    // configuration parameters
    [Range(0.5f, 2f)] [SerializeField] float gameSpeed = 1f;  // Range let's us to decide the min and max value of gameSpeed.
    [SerializeField] int pointsPerBlockDestroyed = 83;        // player will get 83 points for every destroyed block
    TextMeshProUGUI scoreText;
    //[SerializeField] bool isAutoPlayEnabled;

    // state variables
    [SerializeField] int currentScore = 0;

    // cached references
    SceneLoader sceneloader;

    // awake is called before start (and therefore, execution)
    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length; // do not mix the method with FindObjectOfType. this method will keep counting the
                                                                      // gameStatuses and makes it possible for us to know which scene we are currently in.
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);                              // this line is to avoid any thing that might happen before destroying GameStatus.  

            Destroy(gameObject);                                      // if current scene is not the first one, it will delete the next gameStatus and 
        }                                                             // game score won't change.
        else {
            DontDestroyOnLoad(gameObject);                            // if the scene is the first one, it's not going to destroy itself.
        }
    }

    // Start is called before the first frame update
    void Start() {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        scoreText.text = currentScore.ToString();
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update() {
        Time.timeScale = gameSpeed;  // the speed of the game is something we need for every single frame. That's why we write it down here.
        if (Input.GetKeyDown(KeyCode.Escape)) {
            sceneloader.LoadPreviousScene();
        }
    }

    public void addToScore() {
        currentScore += pointsPerBlockDestroyed;              // current score is equal to current score plus pointsPerBlockDestroyed
        scoreText.text = currentScore.ToString();
    }

    public void resetGame() {
        Destroy(gameObject);
        Cursor.visible = true;
    }

    //public bool IsAutoPlayEnabled() {
    //    return isAutoPlayEnabled;
    //}
}
