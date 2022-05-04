using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    readonly string gameScene = "GameScene";
    readonly string menuScene = "MenuScene";

    public void PlayGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
