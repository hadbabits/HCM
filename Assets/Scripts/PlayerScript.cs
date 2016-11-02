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
	private int health;

	void Start (){
		groundContact = false;
		health = 10;
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
		if (other.gameObject.CompareTag ("Enemy")) { //First imp. of health. Will need to work on invicibility frames next
			health--;
			print (health);
		}
			

	}

	void OnCollisionExit2D(Collision2D other) 
	{
		if (other.gameObject.CompareTag ("Ground"))
			groundContact = false;
	}
}
