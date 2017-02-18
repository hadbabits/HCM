﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float jump;

	private Vector2 movement;
	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	private Animator anim;
	private bool groundContact;
	private float initJumpT; //initial jump time

	void Start (){
		groundContact = false;


		anim = GetComponent<Animator> (); //not yet used
		initJumpT = Time.time;

		if (rb == null)
			rb = GetComponent<Rigidbody2D> ();
		if (sprite == null)
			sprite = GetComponent<SpriteRenderer> ();

	}

	void Update () {
		if (Input.GetKey ("left"))
			sprite.flipX = true;
		if (Input.GetKey ("right"))
			sprite.flipX = false;
		
	}

	void FixedUpdate()
	{



		float inputX = Input.GetAxis ("Horizontal");

		movement = new Vector2 (
			speed * inputX,
			rb.velocity.y);

		if (rb == null)
			rb = GetComponent<Rigidbody2D> ();

		rb.velocity = movement;

		if (Input.GetKeyDown (KeyCode.Space) && groundContact) { //Probably need to add jump rate to fix super jump problem
			if (Time.time > initJumpT + 0.5f) {
				initJumpT = Time.time;
				groundContact = false;
				rb.AddForce (Vector2.up * (jump * 100), ForceMode2D.Force); 
			}		
		}
			
	}

	void OnCollisionStay2D (Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
			groundContact = true;
			

	}

	void OnCollisionExit2D(Collision2D other) 
	{
		if (other.gameObject.CompareTag ("Ground"))
			groundContact = false;
	}
}
