using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	private Rigidbody2D rb;
	private static float gunAngle;
	public static int bulletCount;

	public GameObject player;

	void Start () { 
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("Player");
		Physics2D.IgnoreCollision (player.GetComponent<Collider2D> (),
			GetComponent<Collider2D> ());
		Destroy (this.gameObject, 5);
	}
	
	void fixedUpdate () {
		gunAngle = GunRotateScript.gunAngle;

		bulletCount = GameObject.Find ("Level").GetComponent<WorldScript> ().bulletCount; //Not implemented, but may mess with later
	}
}
