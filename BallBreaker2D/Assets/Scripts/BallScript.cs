using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {


    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 2f;
    [SerializeField] float randomMovement = 0.2f;
    bool hasStarted = false;

    Rigidbody2D myRigidBody;

    Vector2 paddleBallGap;
	// Use this for initialization
	void Start () {
        paddleBallGap = transform.position - paddle1.transform.position;
        myRigidBody = GetComponent<Rigidbody2D>().
	}
	
	// Update is called once per frame
	void Update () {
        if(!hasStarted){
            LockBall();
            LaunchOnMouseClick();
        }
	}

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myRigidBody.velocity = new Vector2(xPush,yPush);
            hasStarted = true;
        }
    }

    private void LockBall(){
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleBallGap;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocity = new Vector2(UnityEngine.Random.Range(0f, randomMovement), UnityEngine.Random.Range(0f, randomMovement));
        myRigidBody.velocity += velocity;
    }

}
