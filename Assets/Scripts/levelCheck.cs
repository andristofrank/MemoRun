using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelCheck : MonoBehaviour {

    public void checkAnswer(string x)
    {
        
        float temp = float.Parse(x);
            if (temp == 10)
            {
            FindObjectOfType<GameSession>().LoadNextLevel();
            }
            else
            {
            FindObjectOfType<Health>().LoseLife();
            }
        
    }
    public void goToMainMenu()
    {
        FindObjectOfType<GameSession>().ResetGameSession();
        
    }

}
