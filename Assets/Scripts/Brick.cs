using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;

	public int maxHits;
	private int timesHit;

	public Sprite[] hitSprites;

	private SpriteRenderer brickSpriteRenderer;


	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		brickSpriteRenderer = GetComponent<SpriteRenderer> ();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionExit2D (Collision2D collision) {
		timesHit++;
		if (timesHit >= maxHits) {
			GameObject.Destroy (gameObject);
		} 
		else {
			LoadSprite ();
		}
	}

	void LoadSprite () {
		int spriteIndex = timesHit - 1;
		brickSpriteRenderer.sprite = hitSprites [spriteIndex];
	}

}
