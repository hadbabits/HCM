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

	public Transform ballPrefab;
	public Transform shotGPrefab;
	public Transform gemPrefab;
	public float fireRate;
	public float chargeRate;
	public float maxCharge;
	public float initCharge;
	public float shotBlast;
	public int weaponType;



	void Start () {
		player = GameObject.Find ("Player");
		playerrb = player.GetComponent<Rigidbody2D> ();

		weaponType = 0;

		lastShot = 0f;
	}

	void BallFire (float charge){
		if (Time.time > lastShot + fireRate) {								
			Transform bullet = Instantiate (ballPrefab, newPos, 
				                  transform.rotation) as Transform;
			weaponrb = bullet.GetComponent<Rigidbody2D> ();
			weaponrb.AddForce ((transform.right * charge) + new Vector3 (playerPush, 0f, 0f), ForceMode2D.Impulse);
		}

	} 

	void ShotgunFire (){
	
		if (Time.time > lastShot + fireRate) {								
			Transform bullet1 = Instantiate (Gemerator(), newPos, 
				transform.rotation) as Transform;
			weaponrb = bullet1.GetComponent<Rigidbody2D> ();
			weaponrb.AddForce (Quaternion.AngleAxis(bulletStray(), Vector3.forward) * (transform.right * shotBlast) + new Vector3 (playerPush, 0f, 0f), ForceMode2D.Impulse);
			Transform bullet2 = Instantiate (Gemerator(), newPos, 
				transform.rotation) as Transform;
			weaponrb = bullet2.GetComponent<Rigidbody2D> ();
			//remember this Angle Axis trick for shotguns
			weaponrb.AddForce (Quaternion.AngleAxis(bulletStray(), Vector3.forward) * (transform.right * shotBlast) + new Vector3 (playerPush, 0f, 0f), ForceMode2D.Impulse); 
			Transform bullet3 = Instantiate (Gemerator(), newPos, 
				transform.rotation) as Transform;
			weaponrb = bullet3.GetComponent<Rigidbody2D> ();
			//remember this Angle Axis trick for shotguns
			weaponrb.AddForce (Quaternion.AngleAxis(-bulletStray(), Vector3.forward) * (transform.right * shotBlast) + new Vector3 (playerPush, 0f, 0f), ForceMode2D.Impulse); 
			}
	} 

	Transform Gemerator () {
		if (Random.value > 0.95f)
			return gemPrefab; 
		else
			return shotGPrefab;
	}
		
	float bulletStray (){
	
		float degree = Random.value * 15f; 
		return degree;

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

		if (Input.GetKey (KeyCode.Alpha1))
			weaponType = 0;
		if (Input.GetKey (KeyCode.Alpha2))
			weaponType = 1;

			// Subtract the time when the mouse was pressed from when it's released to determine 
			// the force applied to projectile
		if (Input.GetMouseButtonDown (0))
			chargeInitT = Time.time;
		if (Input.GetMouseButtonUp (0)) {
			charge = Mathf.Clamp (((Time.time - chargeInitT) * chargeRate) + initCharge, 0, maxCharge); 
			if (weaponType == 0)
				BallFire (charge);
			if (weaponType == 1)
				ShotgunFire ();
		}

	}


}
