using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.CompareTag ("Projectile"))
			Destroy (gameObject);
			}
}
