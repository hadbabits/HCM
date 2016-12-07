using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiScript : MonoBehaviour {

	private GameObject player;
	private Rigidbody2D enemyRb;
	private Rigidbody2D swordRb;
	private SpriteRenderer enemySprite;
	private SpriteRenderer swordSprite;
	private float playerDist; // Distance between player and enemy; using to determine direction enemy should face

	public float speed;
	public float maxSpeed;

	void Start () {
		player = GameObject.Find ("Player");
		enemyRb = GetComponent<Rigidbody2D> ();
		swordRb = transform.GetChild (0).GetComponent<Rigidbody2D> ();
		enemySprite = GetComponent<SpriteRenderer> ();
		swordSprite = transform.GetChild (0).GetComponent<SpriteRenderer> ();
	}

	void Update () {
	}

	void FixedUpdate () {
		playerDist = transform.position.x - player.transform.position.x; 

		if (playerDist < 0) { 			//Flips the enemy sprites to follow player
			enemySprite.flipX = true;
			swordSprite.flipX = false;  //note to self: Next time make sure sprites are facing the right way when importing XP
		} else {
			enemySprite.flipX = false;
			swordSprite.flipX = true;
		}

		if (Mathf.Abs (playerDist) < 2) {
			Debug.Log ("close");
			swordRb.AddTorque (5);
		}


		Vector2 velocity = new Vector2 (Mathf.Clamp ((playerDist * speed),-maxSpeed,maxSpeed) + 2, 6); // the + 2 keeps the enemy from stopping when it reaches the player
		enemyRb.velocity = -velocity;

	}
}
