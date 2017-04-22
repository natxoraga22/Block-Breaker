using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;

	private Vector3 paddleToBallVector;
	private bool gameStarted = false;

	private Rigidbody2D ballRigidBody2D;


	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		ballRigidBody2D = GetComponent<Rigidbody2D> ();

		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted) {
			// Lock the ball to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a mouse press to launch
			if (Input.GetMouseButtonDown(0)) {
				gameStarted = true;
				ballRigidBody2D.velocity = new Vector2 (2f, 10f);
			}
		}
	}
}
