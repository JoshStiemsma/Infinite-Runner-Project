﻿using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

	public GameObject PickUp01;
	public GameObject PickUp02;
	public GameObject PickUp03;
	public GameObject PickUp04;

	private SpriteRenderer spriteRenderer01; 
	private SpriteRenderer spriteRenderer02; 
	private SpriteRenderer spriteRenderer03; 
	private SpriteRenderer spriteRenderer04; 

	private float playerPickupCount;
	public Sprite sprite1;
	public Sprite sprite2;




	// Use this for initialization
	void Start () {
		spriteRenderer01 = PickUp01.GetComponent<SpriteRenderer>();
		spriteRenderer02 = PickUp02.GetComponent<SpriteRenderer>();
		spriteRenderer03 = PickUp03.GetComponent<SpriteRenderer>();
		spriteRenderer04 = PickUp04.GetComponent<SpriteRenderer>();


		playerPickupCount =  GameObject.Find ("player").GetComponent<playercontroller> ().pickUpCount;



	}
	
	// Update is called once per frame
	void Update () {
		playerPickupCount =  GameObject.Find ("player").GetComponent<playercontroller> ().pickUpCount;


		if (playerPickupCount == 0) {
			spriteRenderer01.sprite = sprite1;
			spriteRenderer02.sprite = sprite1;
			spriteRenderer03.sprite = sprite1;
			spriteRenderer04.sprite = sprite1;
		}
		if (playerPickupCount == 1) {
			spriteRenderer01.sprite = sprite2;
		}
		if (playerPickupCount == 2) {
			spriteRenderer01.sprite = sprite2;
			spriteRenderer02.sprite = sprite2;
		}
		if (playerPickupCount == 3) {
				spriteRenderer01.sprite = sprite2;
				spriteRenderer02.sprite = sprite2;
				spriteRenderer03.sprite = sprite2;
		}
		if (playerPickupCount == 4) {
				spriteRenderer01.sprite = sprite2;
				spriteRenderer02.sprite = sprite2;
				spriteRenderer03.sprite = sprite2;
				spriteRenderer04.sprite = sprite2;
		}


	}
}