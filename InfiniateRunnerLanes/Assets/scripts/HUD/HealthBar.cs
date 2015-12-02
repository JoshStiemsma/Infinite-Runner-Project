using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	private GameObject player;
	private float playerHealth;

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;

	private bool shield;

	private SpriteRenderer spriteRenderer; 
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		spriteRenderer = GetComponent<SpriteRenderer>();
		playerHealth = player.GetComponent<playercontroller> ().health;
		shield = player.GetComponent<playercontroller> ().shield;
	}
	
	// Update is called once per frame
	void Update () {
		shield = player.GetComponent<playercontroller> ().shield;
		playerHealth = player.GetComponent<playercontroller> ().health;

		if(playerHealth>=76f) {////greater than 75%
			spriteRenderer.sprite = sprite1;
		}

		if (playerHealth <= 75f) {///less than 75%
			if (playerHealth >= 51f) {///greate thn 50%
				spriteRenderer.sprite = sprite2;
			}
		}

		if (playerHealth <= 50f) {
			if (playerHealth >= 26f) {
				spriteRenderer.sprite = sprite3;
			}
			if (playerHealth <= 25f) {
				spriteRenderer.sprite = sprite4;
			}
		}

		if (shield==true) {
			Debug.Log("shield on");
			spriteRenderer.color = new Color (0, 0, 255);
		} else if(shield==false) {
			if(playerHealth>=76f) {////greater than 75%
				spriteRenderer.color = new Color(255,255,255);
			}

			if (playerHealth <= 50f) {
				if (playerHealth >= 26f) {
					spriteRenderer.color = new Color(255,50,0);
				}
				if (playerHealth <= 25f) {
					spriteRenderer.color = new Color(255,0,0);
				}
			}//end if playerhelth under 50//

		}//end if shield on//

	}
}
