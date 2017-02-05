using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotateScript : MonoBehaviour {

	private Vector3 mousePos;
	private Transform weapon;
	private Vector3 objectPos;


	public static float gunAngle; //Used to get Cannon angle in other places

	// Use this for initialization
	void Start () {

		weapon = this.transform;
	}


	void FixedUpdate () {

		mousePos = Input.mousePosition;
		mousePos.z = 5.23f;
		objectPos = Camera.main.WorldToScreenPoint (weapon.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;
		gunAngle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, gunAngle);
		
	}
}
