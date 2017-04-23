using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;

	public Vector2 startVelocity = new Vector2 (2f, 10f);

	private Vector3 paddleToBallVector;
	private bool gameStarted = false;

	private Rigidbody2D ballRigidBody2D;
	private AudioSource ballAudioSource;


	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		ballRigidBody2D = GetComponent<Rigidbody2D> ();
		ballAudioSource = GetComponent<AudioSource> ();

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
				ballRigidBody2D.velocity = startVelocity;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (gameStarted) ballAudioSource.Play ();

		// Randomize the ball velocity to prevent infinite boring loops
		Vector2 tweak = new Vector2 (Random.Range (-0.2f, 0.2f), Random.Range (-0.2f, 0.2f));
		ballRigidBody2D.velocity += tweak;
	}

}
