using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    public void LoadGame()
    {

        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver(){
        StartCoroutine(DelayGameOver());
    }

    private IEnumerator DelayGameOver(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game Over");
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame(){
        Application.Quit();
    }

}
