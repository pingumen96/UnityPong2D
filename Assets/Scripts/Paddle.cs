using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public float impulse = 15.0f;


    private Rigidbody2D rb;
    private Vector2 verticalForceUp;
    private Vector2 verticalForceDown;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        verticalForceUp = new Vector2(0, impulse);
        verticalForceDown = new Vector2(0, -impulse);
    }

    void UpMovement() {
        rb.AddForce(verticalForceUp);
    }

    void DownMovement() {
        rb.AddForce(verticalForceDown);
    }

    void FixedUpdate() {
        if (gameObject.name == "CPUPaddle") {
            if(GameManager.instance.ballPosition.y > rb.position.y) {
                UpMovement();
            } else if(GameManager.instance.ballPosition.y < rb.position.y){
                DownMovement();
            }
        } else {
            if (Input.GetKey("up")) {
                UpMovement();
            }
            else if (Input.GetKey("down")) {
                DownMovement();
            }
        }

    }
}
