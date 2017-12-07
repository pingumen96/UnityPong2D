using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour {
    public float impulse = 15.0f;


    private Rigidbody2D rb;
    private Vector2 verticalForceUp;
    private Vector2 verticalForceDown;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        verticalForceUp = new Vector2(0, impulse);
        verticalForceDown = new Vector2(0, -impulse);
    }
	
	void FixedUpdate () {
        if(Input.GetKey("up")) {
            rb.AddForce(verticalForceUp);
        } else if (Input.GetKey("down")) {
            rb.AddForce(verticalForceDown);
        }
    }
}
