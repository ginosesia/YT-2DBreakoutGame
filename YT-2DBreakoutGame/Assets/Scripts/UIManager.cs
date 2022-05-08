using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text scoreText;
    public Text livesText;

    GameObject globalManager;
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
        scoreText.text = "Score: " + globalScript.score.ToString();
        livesText.text = "Lives: " + globalScript.lives.ToString();
    }
}
