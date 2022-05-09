using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    [SerializeField] GameObject pausePannel;
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
        if (globalScript.isPaused && globalScript.lives > 0)
        {
            pausePannel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePannel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
