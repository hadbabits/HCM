using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	private Rigidbody2D rb;
	private GameObject player;
	private float initHit; // init time shot hits enemy or ground
	private float initFire; //initial time shot is fired

	public static bool damaging;
	public int weaponType; // 0 = ball shot, 1 = shotgun


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

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.CompareTag ("Projectile") && Time.time > initFire + 0.4) //Ignore's collision between projectiles after a certain time after firing, probably needs tweaking.
			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D> (),
				GetComponent<Collider2D> ());
		if (col.gameObject.CompareTag ("Enemy") || col.gameObject.CompareTag ("Ground")) {  // Proj.s won't do damage if they've already hit the enemy or ground
			damaging = false;
			initHit = Time.time;
		}
	}

	void OnCollisionStay2D (Collision2D col){

		if (Time.time > initHit + 0.1 && col.gameObject.CompareTag ("Enemy")) {
			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D> (),
				GetComponent<Collider2D> ());
		}
	}

}
