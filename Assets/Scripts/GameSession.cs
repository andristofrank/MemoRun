using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

    int numberOfLives = 3;
    int levelsLives = 0;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            levelsLives = numberOfLives;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	public void GameOver()
    {
        ResetGameSession();
    }
   
    public void ResetGameSession()
    {
        print("YES");
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    
    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().ToString().Equals("Game Over"))
        {
            ResetGameSession();
        }
        else
        {
            var currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
        }
    }
    public void LoadThisLevel()
    {
        setNumberOfLives(levelsLives);
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over");
    }
    public void setNumberOfLives(int newNumberOfLives)
    {
        numberOfLives = newNumberOfLives;
    }
    public int getNumberOfLives()
    {
        return numberOfLives;
    }
    
}
