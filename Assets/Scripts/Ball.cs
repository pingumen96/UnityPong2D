using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Vector2 initialPosition = new Vector2(0, 0);

    private Rigidbody2D rb;
    private Transform transformMat;
    private bool stopped = true;
    private bool matchStarted = false;
    private Vector2 restartVelocity;


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
        restartVelocity = -rb.velocity;
        rb.velocity = new Vector2(0, 0);
        stopped = true;
    }

    private void StartBall() {
        if(!matchStarted) {
            rb.AddForce(new Vector2(7.0f, 7.0f), ForceMode2D.Force);
            matchStarted = true;
        } else {
            rb.velocity = restartVelocity;
        }
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

    private void OnCollisionExit2D(Collision2D collision) {
        // se abbiamo colpito nella parte alta, allora la pallina andrà verso l'alto, altrimenti verso il basso
        if(collision.gameObject.tag == "Paddle") {
            Debug.Log("Collisione");
            if (gameObject.transform.position.y > collision.transform.position.y) {
                Debug.Log("Su");
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Abs(rb.velocity.y));
            } else {
                Debug.Log("Giù");
                rb.velocity = new Vector2(rb.velocity.x, -Mathf.Abs(rb.velocity.y));
            }
        }
    }
}

