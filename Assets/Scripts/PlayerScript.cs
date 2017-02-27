using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float jump;
	public float jumpCool; //Jump cooldown to prevent super jump
	public float airDrag; //Slows descent to make jump more realistic
	public float flipped; //is sprite flipped (public for other script access)

	private Vector2 movement;
	private Rigidbody2D rb;
	private Transform tf;
	private Animator anim;
	private bool groundContact;
	private float initJumpT; //initial jump time

	void Start (){
		groundContact = false;


		anim = GetComponent<Animator> (); //not yet used
		initJumpT = Time.time;

		if (rb == null)
			rb = GetComponent<Rigidbody2D> ();

		if (tf == null)
			tf = GetComponent<Transform> ();

		flipped = 1;

	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.Space) && groundContact) {
			if (Time.time > initJumpT + jumpCool) {
				initJumpT = Time.time;
				groundContact = false;
				rb.AddForce (Vector2.up * (jump * 100), ForceMode2D.Force); 
			}		
		}

	}

	void FixedUpdate()
	{



		float inputX = Input.GetAxis ("Horizontal");

		movement = new Vector2 (
			speed * inputX,
			rb.velocity.y * airDrag);


		rb.velocity = movement;


			
			
		if (Input.GetKey ("left") || Input.GetKey (KeyCode.A)) {
			flipped = -1;
			tf.localScale = new Vector3 (-60, tf.localScale.y, tf.localScale.z);
		}
		if (Input.GetKey ("right") || Input.GetKey (KeyCode.D)) {
			flipped = 1;
			tf.localScale = new Vector3 (60, tf.localScale.y, tf.localScale.z);
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
			groundContact = true;
		if (other.gameObject.CompareTag ("Hazard"))
			Destroy (this.gameObject); 
			

	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("Ground"))
			groundContact = false;
	}
}
