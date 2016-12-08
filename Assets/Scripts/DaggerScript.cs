using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : MonoBehaviour {

	private bool damaging;
	private Rigidbody2D daggerRb;
	private Rigidbody2D playerRb;

	void Start () {
		damaging = false;
		daggerRb = GetComponent<Rigidbody2D> ();
		playerRb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (Input.GetMouseButton (1)) {
			Debug.Log ("Dag!");
			daggerRb.position.x += 50;
		}
	}
}
