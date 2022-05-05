using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    readonly string horizontal = "Horizontal";
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] GameObject globalManager;
    GlobalScript globalScript;


    float speed = 15f;
    float horizontalInput;

    float leftBoundary = -3.8f;
    float rightBoundary = 3.8f;

    // Start is called before the first frame update
    void Start()
    {
        globalScript = globalManager.GetComponent<GlobalScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!globalScript.isPaused)
        {
            //Move Paddle
            MovePaddle();
        }
    }

    public void MovePaddle()
    {
        horizontalInput = Input.GetAxis(horizontal);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
        }


        if (transform.position.x < leftBoundary)
        {
            transform.position = new Vector2(leftBoundary, transform.position.y);
        }


        if (transform.position.x > rightBoundary)
        {
            transform.position = new Vector2(rightBoundary, transform.position.y);
        }
    }
}