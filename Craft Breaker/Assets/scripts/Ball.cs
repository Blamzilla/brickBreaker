using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Config Params

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField] AudioClip[] ballSounds;

    //State

    Vector2 paddleToBallVector;
    bool hasStarted = false;
    //Cached Refs

    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {

        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }

    }

    private void LaunchOnClick()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }

    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        string hasCollided = collision.gameObject.name;
        
        if (hasStarted && hasCollided == "Paddle")
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
             myAudioSource.PlayOneShot(clip);

              
        }
        
    }

  
}
