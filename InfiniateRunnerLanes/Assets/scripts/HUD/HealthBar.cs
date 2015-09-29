using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	private float playerHealth;

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;


	private SpriteRenderer spriteRenderer; 
	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer>();
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;

		if(playerHealth>=76f) {////greater than 75%
			spriteRenderer.sprite = sprite1;
			spriteRenderer.color = new Color(255,255,255);
		}
		if (playerHealth <= 75f) {///less than 75%
			if (playerHealth >= 51f) {///greate thn 50%
				spriteRenderer.sprite = sprite2;
			}
		}
		if (playerHealth <= 50f) {
			if (playerHealth >= 26f) {
				spriteRenderer.sprite = sprite3;
				spriteRenderer.color = new Color(255,50,0);
			}
			if (playerHealth <= 25f) {
				spriteRenderer.sprite = sprite4;
				spriteRenderer.color = new Color(255,0,0);
			}
		}
	}
}
