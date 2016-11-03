using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

	public int health;
	public bool isEnemy;

	public void damage (int damageCount){
		health -= damageCount;
		if (health <= 0)
			Destroy (gameObject);
	}

	void Start () {
		
	}


	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.CompareTag ("Enemy") && !isEnemy) {
			damage (1);
			Debug.Log ("Player " + health);
		}
		if (col.gameObject.CompareTag ("Projectile") && isEnemy) {
			damage (1);
			Debug.Log ("Enemy " + health);
		}
	}


}
