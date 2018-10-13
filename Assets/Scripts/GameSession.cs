using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
    int score;

    LivesDisplay livesDisplay;
    // Use this for initialization
    void Awake()
    {
        SetUpSingleton();
    }

    void Start(){
        livesDisplay = FindObjectOfType<LivesDisplay>();
        UpdateLives();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetPlayerLives()
    {
        return playerLives;
    }

    public void LoseLife(){
        playerLives--;
        UpdateLives();

    }

    public void AddLives(int lives){
        playerLives += lives;
        UpdateLives();
    }

    public void UpdateLives(){
        if (livesDisplay != null && playerLives >= 1)
        {
            livesDisplay.GetComponent<Text>().text = ":" + playerLives.ToString();
        }
        else 
        {
            livesDisplay = null;
        }
    }

    public void AddToScore(int value)
    {
        score += value;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
