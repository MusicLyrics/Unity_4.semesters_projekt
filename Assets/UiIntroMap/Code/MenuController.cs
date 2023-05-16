using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
    {
        //Load the "map" Scene, when the StartBtn() get trigged
        SceneManager.LoadScene("map");
    }

    public void QuitGame()
    {
        //Close the game. when the Quitgame() get trigged
        Application.Quit();
    }
}
