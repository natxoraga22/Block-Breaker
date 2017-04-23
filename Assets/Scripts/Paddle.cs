using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	void Update () {
		// Make the paddle follow the mouse X position
		float mousePositionInBlocks = (Input.mousePosition.x / Screen.width) * 16;
		Vector3 paddlePosition = new Vector3(Mathf.Clamp(mousePositionInBlocks, 0.5f, 15.5f), this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePosition;
	}
}
