using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject globalManager;
    GlobalScript globalScript;

    readonly string globalManagerTag = "GlobalManager";

    // Start is called before the first frame update
    void Start()
    {
        globalManager = GameObject.FindGameObjectWithTag(globalManagerTag);
        globalScript = globalManager.GetComponent<GlobalScript>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(globalScript.lives < 0)
        {
            gameOverPanel.SetActive(true);
            globalScript.isPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            gameOverPanel.SetActive(false);
            globalScript.isPaused = false;
            Time.timeScale = 1f;
        }
    }
}
