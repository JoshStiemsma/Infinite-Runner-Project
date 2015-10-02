
using UnityEngine;
using System.Collections;

public class FuelBar : MonoBehaviour {
	private float playerFuel;

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	public Sprite sprite5;
	public Sprite sprite6;
	public Sprite sprite7;
	public Sprite sprite8;

	private SpriteRenderer spriteRenderer; 
	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer>();
		playerFuel = GameObject.Find ("player").GetComponent<playercontroller> ().fuel;
	}
	
	// Update is called once per frame
	void Update () {
		playerFuel = GameObject.Find ("player").GetComponent<playercontroller> ().fuel;

		if(playerFuel>=85f) {////greater than 85%
			spriteRenderer.sprite = sprite1;
			spriteRenderer.color = new Color(255,255,255);
		}
		if(playerFuel<85f) {////less than 85%
			spriteRenderer.sprite = sprite2;
			
		}
		if(playerFuel<70f) {////less than 85%
			spriteRenderer.sprite = sprite3;
			
		}
		if(playerFuel<56f) {////less than 85%
			spriteRenderer.sprite = sprite4;
			
		}
		if(playerFuel<42f) {////less than 85%
			spriteRenderer.sprite = sprite5;

		}
		if(playerFuel<28f) {////less than 85%
			spriteRenderer.sprite = sprite6;
			spriteRenderer.color = new Color(255,255,0);
		}
		if(playerFuel<14f) {////less than 85%
			spriteRenderer.sprite = sprite7;
			spriteRenderer.color = new Color(255,128,0);
		}
		if(playerFuel<1f) {////less than 85%
			spriteRenderer.sprite = sprite8;
			spriteRenderer.color = new Color(255,0,0);
		}
		}

}
