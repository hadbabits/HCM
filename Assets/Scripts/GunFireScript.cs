using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireScript : MonoBehaviour {


	private Rigidbody2D weaponrb;
	private Rigidbody2D playerrb;
	private GameObject player;
	private float lastShot;
	private Vector3 newPos;

	public Transform shotPrefab;
	public float fireRate;
	public float firePower;


	void Start () {
		player = GameObject.Find ("Player");
		playerrb = player.GetComponent<Rigidbody2D> ();

		lastShot = 0;
	}

	void BallFire (){
		if (Time.time > lastShot + fireRate) {
			Transform bullet = Instantiate (shotPrefab, newPos, 
				                  transform.rotation) as Transform;
			weaponrb = bullet.GetComponent<Rigidbody2D> ();
			weaponrb.AddForce ((transform.right * firePower) + new Vector3 (1, 0f, 0f), ForceMode2D.Impulse);

			lastShot = Time.time;
		}

	} 


	void Update () {

		newPos = transform.position;


		if (Input.GetMouseButtonDown (0)) {
			BallFire ();
		}

	}


}
