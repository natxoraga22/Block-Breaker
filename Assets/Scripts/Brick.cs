using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int breackableCount = 0;

	private LevelManager levelManager;
	private SpriteRenderer brickSpriteRenderer;

	public AudioClip crackSound;

	private bool isBreakable;
	private int timesHit;
	public Sprite[] hitSprites;


	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		brickSpriteRenderer = GetComponent<SpriteRenderer> ();
		timesHit = 0;

		isBreakable = (this.tag == "Breakable");
		if (isBreakable) breackableCount++;
	}

	void OnCollisionExit2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (crackSound, this.transform.position);
		if (isBreakable) HandleHit ();
	}

	void HandleHit () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breackableCount--;
			// Load the next level if this is the last breackable block
			if (breackableCount <= 0) levelManager.LoadNextLevel ();
			GameObject.Destroy (gameObject);
		} 
		else {
			LoadSprite ();
		}
	}

	void LoadSprite () {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			brickSpriteRenderer.sprite = hitSprites [spriteIndex];
		}
	}

}
