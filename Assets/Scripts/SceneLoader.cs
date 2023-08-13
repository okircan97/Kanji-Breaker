using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour {

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Cursor.visible = true;
    }

    public void LoadPreviousScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
        Cursor.visible = true;
    }

    public void LoadStartScene() {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().resetGame();    // it finds the game status object and calls the reset game function from the GameStatus class.
        Cursor.visible = true;
    }

    public void LoadKanjiCollection()
    {
        SceneManager.LoadScene(22);
        Cursor.visible = true;
    }

    public void LoadLevel1() {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameStatus>().resetGame();
        Cursor.visible = true;
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
        FindObjectOfType<GameStatus>().resetGame();
        Cursor.visible = true;
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(5);
        FindObjectOfType<GameStatus>().resetGame();
        Cursor.visible = true;
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene(7);
        FindObjectOfType<GameStatus>().resetGame();
        Cursor.visible = true;
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene(9);
        FindObjectOfType<GameStatus>().resetGame();
        Cursor.visible = true;
    }

    public void LoadLevel6()
    {
        SceneManager.LoadScene(11);
        FindObjectOfType<GameStatus>().resetGame();
        Cursor.visible = true;
    }

    public void LoadLevel7()
    {
        SceneManager.LoadScene(13);
        FindObjectOfType<GameStatus>().resetGame();
        Cursor.visible = true;
    }

    public void LoadLevel8()
    {
        SceneManager.LoadScene(15);
        FindObjectOfType<GameStatus>().resetGame();
        Cursor.visible = true;
    }

    public void LoadLevel9()
    {
        SceneManager.LoadScene(17);
        FindObjectOfType<GameStatus>().resetGame();
        Cursor.visible = true;
    }

    public void LoadLevel10()
    {
        SceneManager.LoadScene(19);
        FindObjectOfType<GameStatus>().resetGame();
        Cursor.visible = true;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
