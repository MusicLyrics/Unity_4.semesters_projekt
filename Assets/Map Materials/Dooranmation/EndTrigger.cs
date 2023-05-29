using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        CompleteLevel();
    }


    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public void CompleteLevel() 
    {
        Debug.Log("Level Won!");
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }
}
