using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    public bool isPaused = false;
    public bool isDead = false;
    public Transform ballLocation;
    public GameObject ball;

    public int score = 0;
    public int lives = 3;

    private void Update()
    {
        if (isDead) {
            Instantiate(ball, ballLocation.position, Quaternion.identity);
            isDead = false;
        }
    }
}
