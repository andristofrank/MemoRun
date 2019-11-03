using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] GameObject heart1;
    [SerializeField] GameObject heart2;
    [SerializeField] GameObject heart3;

    int numberOfLives;
        void Start()
    {
        

    }
    public void Update()
    {
        numberOfLives = FindObjectOfType<GameSession>().getNumberOfLives();
        print("NumberoFLives" + numberOfLives);
        showlifeScore(numberOfLives);
    }

    public void LoseLife()
    {
        if (numberOfLives > 1)
        {
            numberOfLives--;
            FindObjectOfType<GameSession>().setNumberOfLives(numberOfLives);
            showlifeScore(numberOfLives);
        }
        else
        {
            FindObjectOfType<GameSession>().LoadGameOverScene();
        }
    }
    void showlifeScore(int score)
    {
        if (score == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (score == 2)
        {
            heart1.SetActive(false);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (score == 1)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(true);
        }
        else
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
    }
    // Use this for initialization
    
    public void WinLife()
    {
        if (numberOfLives == 3)
        {
            return;
        }
        numberOfLives++;
        FindObjectOfType<GameSession>().setNumberOfLives(numberOfLives);
        showlifeScore(numberOfLives);
    }
}
