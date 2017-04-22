using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float mousePositionInBlocks = (Input.mousePosition.x / Screen.width) * 16;
		Vector3 paddlePosition = new Vector3(Mathf.Clamp(mousePositionInBlocks, 0.5f, 15.5f), this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePosition;
	}
}
