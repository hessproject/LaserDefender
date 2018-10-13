using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    [SerializeField] GameObject playerPrefab;

    Level level;
    GameSession gameSession;

	// Use this for initialization
	void Start () {
        level = GameObject.Find("SceneManager").GetComponent<Level>();
        gameSession = FindObjectOfType<GameSession>();
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
	
    public void HandleDeath(){
        gameSession.LoseLife();
        if(gameSession.GetPlayerLives() <= 0){
            level.LoadGameOver();
        } else {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn(){
        yield return new WaitForSeconds(1);
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
