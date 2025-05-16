using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void StartGameButton()
    {
        // load the game scene
        SceneManager.LoadScene("GameScene");
    }

    public void QuitButton()
    {
        // test that the button works
        Debug.Log("QUIT!");
        // quit (only works in build)
        Application.Quit();
    }
}
