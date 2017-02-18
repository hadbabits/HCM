using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	private Rigidbody2D rb;
	private GameObject player;
	private float initHit; // init time shot hits enemy or ground
	private float initFire; //initial time shot is fired

	public static bool damaging;


	void Start () { 
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("Player");
		Physics2D.IgnoreCollision (player.GetComponent<Collider2D> (),
			GetComponent<Collider2D> ());

		damaging = true;

		initFire = Time.time;

		Destroy (this.gameObject, 5);
	}
	
	void fixedUpdate () {
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.CompareTag ("Enemy") || col.gameObject.CompareTag ("Ground")) {  // Proj.s won't do damage if they've already hit the enemy or ground
			damaging = false;
			initHit = Time.time;
			Destroy (this.gameObject,0);
		}
	}

}
