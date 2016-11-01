using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireScript : MonoBehaviour {

	private Vector3 newPos;
	private Rigidbody2D weaponrb;
	private float lastShot;
	private float charge; 
	private float chargeInitT; //time when mouse1 pressed/initial charge time
	private Rigidbody2D playerrb;
	private float playerVel;
	private float playerPush;
	private GameObject player;

	public Transform weaponPrefab;
	public float fireRate;
	public float chargeRate;
	public float maxCharge;
	public float initCharge;




	void Start () {
		player = GameObject.Find ("Player");
		playerrb = player.GetComponent<Rigidbody2D> ();

		lastShot = 0f;
	}

	void Fire (float charge){
		if (Time.time > lastShot + fireRate) {
			Transform weapon = Instantiate (weaponPrefab, newPos, 
				                  transform.rotation) as Transform;
			weaponrb = weapon.GetComponent<Rigidbody2D> ();
			weaponrb.AddForce ((weapon.transform.right * charge) + new Vector3 (playerPush, 0f, 0f), ForceMode2D.Impulse);
			lastShot = Time.time;
		}
	} 
	void Update () {

		// playerPush adds momentum from the player into the shot; otherwise the player might move forward
		// and run into their own shot, for ex. 
		// The cases below determine if the players aimed in the same direction their facing and adjusts
		// playerPush accordingly.
		playerVel = playerrb.velocity.x;
		if (Mathf.Abs (GunRotateScript.gunAngle) < 90 && playerVel < 0) { //Aimed Right/Moving Back
			playerPush = Mathf.Abs (playerVel) * 0.25f;
		}
		if (Mathf.Abs (GunRotateScript.gunAngle) < 90 && playerVel >= 0) { //Aimed Right/Moving Forward
			playerPush = Mathf.Abs (playerVel) * 0.75f;
		}
		if (Mathf.Abs (GunRotateScript.gunAngle) > 90 && playerVel < 0) { //Aimed Left/Moving Forward
			playerPush = (Mathf.Abs (playerVel) * -1f) * 0.75f;
		}
		if (Mathf.Abs (GunRotateScript.gunAngle) > 90 && playerVel >= 0) { //Aimed Left/Moving Back
			playerPush = (Mathf.Abs (playerVel) * -1f) * 0.25f;
		}

		newPos = transform.position;

		// Subtract the time when the mouse was pressed from when it's released to determine 
		// the force applied to projectile
		if (Input.GetMouseButtonDown (0))
			chargeInitT = Time.time;
		if (Input.GetMouseButtonUp (0)) {
			charge = Mathf.Clamp(((Time.time - chargeInitT) * chargeRate) + initCharge, 0, maxCharge); 
			Debug.Log (charge);
			Fire (charge);
		}

		
	}


}
