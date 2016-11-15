using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairScript : MonoBehaviour {

	private float initialZ; //initial Z pos of crosshair
	private Vector3 mousePos;
	public Camera cameraPos;
	private float testAngle;

	void Start () {

		initialZ = Mathf.Abs((cameraPos.transform.position.z - transform.position.z));


	}

	void FixedUpdate () {

		mousePos = Input.mousePosition;
		mousePos.z = initialZ;

		transform.position = Camera.main.ScreenToWorldPoint(mousePos);
	}
}
