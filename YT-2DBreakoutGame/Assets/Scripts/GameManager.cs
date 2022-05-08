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
    public GameObject pausePannel;

    GameObject globalManager;
    GlobalScript globalScript;

    readonly string globalManagerTag = "GlobalManager";


    int numberOfBlocks;
    int levelNumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        globalManager = GameObject.FindGameObjectWithTag(globalManagerTag);
        globalScript = globalManager.GetComponent<GlobalScript>();

        //pausePannel = GameObject.Find("PausePannel");
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


            if (globalScript.isPaused)
            {
                pausePannel.gameObject.SetActive(true);
            }
            else
            {
                pausePannel.gameObject.SetActive(false);
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

    public void ExitGame()
    {
        Application.Quit();
    }



}
