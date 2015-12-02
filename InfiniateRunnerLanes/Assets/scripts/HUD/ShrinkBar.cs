using UnityEngine;
using System.Collections;

public class ShrinkBar : MonoBehaviour {
	private GameObject player;
	private float playerHealth;

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;

	private float shrinkCounter;

	private SpriteRenderer spriteRenderer; 
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		spriteRenderer = GetComponent<SpriteRenderer>();
		playerHealth = player.GetComponent<playercontroller> ().health;
		shrinkCounter = player.GetComponent<playercontroller> ().shrinkCounter;
	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = player.GetComponent<playercontroller> ().health;
		shrinkCounter = player.GetComponent<playercontroller> ().shrinkCounter;

		//Debug.Log (shrinkCounter);
		if(shrinkCounter<=0.1f) {////greater than 75%
			spriteRenderer.sprite = sprite1;
		}
		if(shrinkCounter>=1f) {////greater than 75%
			spriteRenderer.sprite = sprite2;
		}
		if(shrinkCounter>=2f) {////greater than 75%
			spriteRenderer.sprite = sprite3;
		}
		if(shrinkCounter>=3f) {////greater than 75%
			spriteRenderer.sprite = sprite4;
		}



		if (shrinkCounter >= 3f) {
			spriteRenderer.color = new Color (255, 0, 0);
		} else {
			spriteRenderer.color = new Color (255, 255, 0);

		}

	}
}
