using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(10.0f, 10.0f), ForceMode2D.Force);
	}
	
	void Update () {
		
	}
}
