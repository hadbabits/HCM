using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureShotScript : MonoBehaviour {

	private Rigidbody2D rb;
	private GameObject player;


	void Start () { 
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("Player");
		Physics2D.IgnoreCollision (player.GetComponent<Collider2D> (),
			GetComponent<Collider2D> ());

		Destroy (this.gameObject, 5);
	}

	void fixedUpdate () {
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.CompareTag ("Projectile"))
			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D> (),
				GetComponent<Collider2D> ());
		rb.gravityScale = 1;		//Doesn't work yet


		
	}
}
