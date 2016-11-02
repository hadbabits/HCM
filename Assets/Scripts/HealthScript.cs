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


}
