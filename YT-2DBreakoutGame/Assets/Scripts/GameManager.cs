using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    readonly string gameScene = "GameScene";
    readonly string menuScene = "MenuScene";
    readonly string block = "Block";

    [SerializeField] Transform[] blockLevels;

    GameObject globalManager;
    GlobalScript globalScript;

    readonly string globalManagerTag = "GlobalManager";
    private string sceneName;

    //Ints
    int numberOfBlocks;
    int levelNumber = 1;



    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if(sceneName != menuScene)
        {
            globalManager = GameObject.FindGameObjectWithTag(globalManagerTag);
            globalScript = globalManager.GetComponent<GlobalScript>();
        }
    }

    private void Update()
    {
        var sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "GameScene")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                globalScript.isPaused = true;
            }

            numberOfBlocks = GameObject.FindGameObjectsWithTag(block).Length;

            if (numberOfBlocks <= 0)
            {
                LoadInBlockLevel();
                levelNumber++;
            }
        }
    }


    private void LoadInBlockLevel()
    {
        Instantiate(blockLevels[levelNumber], Vector2.zero, Quaternion.identity);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void ResumeGame()
    {
        globalScript.isPaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}