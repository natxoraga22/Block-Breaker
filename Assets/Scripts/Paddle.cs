using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float minXPosition = 1f;
	public float maxXPosition = 15f;

	public bool autoPlay = false;
	private Ball ball;


	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();
		} 
		else {
			AutoPlay ();
		}
	}

	void MoveWithMouse () {
		// Make the paddle follow the mouse X position
		float mouseXPosition = (Input.mousePosition.x / Screen.width) * 16;
		Vector3 paddlePosition = new Vector3(Mathf.Clamp(mouseXPosition, minXPosition, maxXPosition), this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePosition;
	}

	void AutoPlay () {
		// Paddle always below the ball
		float ballXPosition = ball.transform.position.x;
		Vector3 paddlePosition = new Vector3(Mathf.Clamp(ballXPosition, minXPosition, maxXPosition), this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePosition;
	}

}
