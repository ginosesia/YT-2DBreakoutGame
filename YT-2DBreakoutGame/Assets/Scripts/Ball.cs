﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    float ballForce = 500;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Transform pinkEffect;
    [SerializeField] Transform blueEffect;

    GameObject soundManager;
    GameObject globalManager;
    SoundScript soundScript;
    GlobalScript globalScript;

    
    readonly string soundManagerTag = "SoundManager";
    readonly string globalManagerTag = "GlobalManager";
    readonly string outOfBounds = "OutOfBounds";
    readonly string block = "Block";
    readonly string pinkBlock = "PinkBlock";
    readonly string blueBlock = "BlueBlock";

    private Vector3 startPosition;

    bool ballInPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

        globalManager = GameObject.FindGameObjectWithTag(globalManagerTag);
        globalScript = globalManager.GetComponent<GlobalScript>();

        soundManager = GameObject.FindGameObjectWithTag(soundManagerTag);
        soundScript = soundManager.GetComponent<SoundScript>();

        transform.position = globalScript.ballLocation.transform.position;
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
            //Destroy Ball
            Destroy(gameObject);
            //Set is dead to true 
            globalScript.isDead = true;
            //Play sound
            soundScript.PlaySound(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == block)
        {
            Destroy(collision.gameObject);
            if(collision.gameObject.name == pinkBlock)
            {
                PlayEffect(pinkEffect, collision);
            }
            if (collision.gameObject.name == blueBlock)
            {
                PlayEffect(blueEffect, collision);
            }

        }
    }

    public void PlayEffect(Transform transform, Collision2D collision)
    {

        //Play particle effect on block break
        Transform effect = Instantiate(transform, collision.transform.position, collision.transform.rotation);

        soundScript.PlaySound(0);

        Destroy(effect.gameObject, 1.5f);
    }

}
