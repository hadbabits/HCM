using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiScript : MonoBehaviour {

	private GameObject player;

	public GameObject target;

	void Start () {
		player = GameObject.Find ("Player");
	}

	void Update () {
		
	}
}
