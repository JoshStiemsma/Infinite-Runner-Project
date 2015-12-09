using UnityEngine;
using System.Collections;

public class GrowBar : MonoBehaviour {
	private GameObject player;
	private float playerHealth;

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;

	private float growCounter;

	private SpriteRenderer spriteRenderer; 
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		spriteRenderer = GetComponent<SpriteRenderer>();
		playerHealth = player.GetComponent<playercontroller> ().health;
		growCounter = player.GetComponent<playercontroller> ().growCounter;
	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = player.GetComponent<playercontroller> ().health;
		growCounter = player.GetComponent<playercontroller> ().growCounter;

		//Debug.Log (growCounter);
		if(growCounter<=0.1f) {////greater than 75%
			spriteRenderer.sprite = sprite1;
		}
		if(growCounter>=1f) {////greater than 75%
			spriteRenderer.sprite = sprite2;
		}
		if(growCounter>=2f) {////greater than 75%
			spriteRenderer.sprite = sprite3;
		}
		if(growCounter>=3f) {////greater than 75%
			spriteRenderer.sprite = sprite4;
		}



			if (growCounter >= 3f) {
			spriteRenderer.color = new Color (255, 0, 0);
		} else {
			spriteRenderer.color = new Color (255, 0, 255);

		}

	}
}
