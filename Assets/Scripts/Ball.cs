using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Vector2 initialPosition = new Vector2(0, 0);

    private Rigidbody2D rb;
    private Transform transformMat;
    private bool stopped = true;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        transformMat = GetComponent<Transform>();

        // si setta posizione iniziale della pallina
        ResetPosition();
	}
	
	void Update () {
        if(stopped && Input.GetKeyDown("space")) {
            StartBall();
            stopped = false;
        }
	}

    private void ResetPosition() {
        transformMat.position = initialPosition;
        rb.velocity = new Vector2(0, 0);
        stopped = true;
    }

    private void StartBall() {
        rb.AddForce(new Vector2(10.0f, 10.0f), ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "GoalCollider") {
            if (collision.name == "PlayerScoreCollider") {
                GameManager.instance.incrementCPUScore();
            } else {
                GameManager.instance.incrementPlayerScore();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "GoalCollider") {
            ResetPosition();
        }
    }
}

