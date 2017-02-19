using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireScript : MonoBehaviour {


	private Rigidbody2D weaponrb;
	private GameObject player;
	private PlayerScript pScript;
	private float lastShot;
	private Vector3 newPos;

	public Transform shotPrefab;
	public float fireRate;
	public float firePower;
	public float flipped; //from playerscript 


	void Start () {
		player = GameObject.Find ("Player");
		pScript = player.GetComponent <PlayerScript> ();
			
		lastShot = 0;

	}

	void BallFire (){
		if (Time.time > lastShot + fireRate) {
			Transform bullet = Instantiate (shotPrefab, newPos, 
				                  transform.rotation) as Transform;
			weaponrb = bullet.GetComponent<Rigidbody2D> ();
			weaponrb.AddForce ((flipped * transform.right * firePower) + new Vector3 (1, 0f, 0f), ForceMode2D.Impulse);

			lastShot = Time.time;
		}

	} 


	void Update () {

		newPos = transform.position;


		if (Input.GetMouseButtonDown (0)) 
			BallFire ();
			
		flipped = pScript.flipped;

	}


}
