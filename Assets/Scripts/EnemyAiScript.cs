using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiScript : MonoBehaviour {

	private GameObject player;
	private Rigidbody2D enemyRb;

	public float speed;

	void Start () {
		player = GameObject.Find ("Player");
		enemyRb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		
	}

	void FixedUpdate () {
		Vector2 velocity = new Vector2 ((transform.position.x - player.transform.position.x) * speed, 0);
		enemyRb.velocity = -velocity;
	}
}
