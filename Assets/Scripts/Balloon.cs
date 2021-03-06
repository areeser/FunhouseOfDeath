﻿using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {
    public bool balloonOut;
    public float upForce = 10.0f;
    public float maxVelocity = 10.0f;
	// Use this for initialization
	void Start () {
        balloonOut = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (LockPowers.BalloonUnlocked)
        {
            if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.LeftShift)) && gameObject.GetComponent<PlayerMovement>().touchingGround)
            {
                balloonOut = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                gameObject.GetComponent<PlayerMovement>().canMove = false;
            }
            else if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.LeftShift))
            {
                balloonOut = false;
                gameObject.GetComponent<PlayerMovement>().canMove = true;
            }
            if (balloonOut)
            {
                /*gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0.0f);
                gameObject.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));*/
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, upForce * Time.deltaTime));
                if (gameObject.GetComponent<Rigidbody2D>().velocity.y > maxVelocity) {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, maxVelocity);
                }
            }
        }
	}
}
