using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float jump;
	public float jumpMultiplier;

	private Vector2 movement;
	private Rigidbody2D rb;
	private bool groundContact;
	private Animator anim;

	void Start (){
		groundContact = false;
		anim = GetComponent<Animator> (); //not yet used
	}

	void Update () {

		
	}

	void FixedUpdate()
	{
		if (rb == null)
			rb = GetComponent<Rigidbody2D> ();

		float inputX = Input.GetAxis ("Horizontal");

		movement = new Vector2 (
			speed * inputX,
			rb.velocity.y);

		if (rb == null)
			rb = GetComponent<Rigidbody2D> ();

		rb.velocity = movement;

		if (Input.GetKeyDown (KeyCode.Space) && groundContact)
			rb.AddForce (Vector2.up * (jump * jumpMultiplier), ForceMode2D.Force); 
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
