using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiScript : MonoBehaviour {

	private GameObject player;
	private Rigidbody2D enemyRb;
	private SpriteRenderer enemySprite;
	private float playerDist; // Distance between player and enemy; using to determine direction enemy should face

	public float speed;
	public float maxSpeed;

	void Start () {
		player = GameObject.Find ("Player");
		enemyRb = GetComponent<Rigidbody2D> ();
		enemySprite = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		
	}

	void FixedUpdate () {
		playerDist = transform.position.x - player.transform.position.x; 

		if (playerDist < 0)
			enemySprite.flipX = true;
		else
			enemySprite.flipX = false;


		Vector2 velocity = new Vector2 (Mathf.Clamp ((playerDist * speed),-maxSpeed,maxSpeed) + 2, 6); // the + 2 keeps the enemy from stopping when it reaches the player
		enemyRb.velocity = -velocity;
		Debug.Log (enemyRb.velocity);

	}
}
