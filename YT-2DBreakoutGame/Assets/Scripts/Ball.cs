using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    float ballForce = 500;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] GameObject globalManager;
    GlobalScript globalScript;


    readonly string outOfBounds = "OutOfBounds";
    readonly string block = "Block";

    private Vector3 startPosition;

    bool ballInPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        globalScript = globalManager.GetComponent<GlobalScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!globalScript.isPaused)
        {
            //Add force to the ball
            AddForce();
        }
    }

     
    public void AddForce()
    {
        if(!ballInPlay) {
            if (Input.GetButtonDown("Jump"))
            {
                rigidbody.AddForce(Vector2.up * ballForce);
                ballInPlay = true;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == outOfBounds)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == block)
        {
            Destroy(collision.gameObject);
        }
    }
}
