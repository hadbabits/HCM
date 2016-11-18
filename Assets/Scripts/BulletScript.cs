using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	private Rigidbody2D rb;
	private GameObject player;
	private float initT;

	public static bool damaging;
	public int weaponType; // 0 = ball shot, 1 = shotgun


	void Start () { 
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("Player");
		Physics2D.IgnoreCollision (player.GetComponent<Collider2D> (),
			GetComponent<Collider2D> ());

		damaging = true;

		Destroy (this.gameObject, 5);
	}
	
	void fixedUpdate () {
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.CompareTag ("Projectile"))
			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D> (),
				GetComponent<Collider2D> ());
		if (weaponType == 1) {
			if (!col.gameObject.CompareTag ("Projectile")) {
				rb.gravityScale = 10f;
				rb.mass = 10f;
			}
		}

		if (col.gameObject.CompareTag ("Enemy")) {
			damaging = false;
			initT = Time.time;
		}
	}

	void OnCollisionStay2D (Collision2D col){

		if (Time.time > initT + 0.1 && col.gameObject.CompareTag ("Enemy")) {
			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D> (),
				GetComponent<Collider2D> ());
		}
	}

}
