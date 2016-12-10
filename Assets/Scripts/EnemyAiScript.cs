using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiScript : MonoBehaviour {

	private GameObject player;
	private Rigidbody2D enemyRb;
	private Rigidbody2D swordRb;
	private SpriteRenderer enemySprite;
	private SpriteRenderer swordSprite;
	private Animator swordAnim;
	private float playerDist; // Distance between player and enemy; using to determine direction enemy should face

	public float speed;
	public float maxSpeed;

	void Start () {
		player = GameObject.Find ("Player");
		enemyRb = GetComponent<Rigidbody2D> ();
		swordRb = transform.GetChild (0).GetComponent<Rigidbody2D> ();
		enemySprite = GetComponent<SpriteRenderer> ();
		swordSprite = transform.GetChild (0).GetComponent<SpriteRenderer> ();
		swordAnim = transform.GetChild (0).GetComponent<Animator> ();
	}

	void Update () {
	}

	void FixedUpdate () {
		playerDist = transform.position.x - player.transform.position.x; 

		if (Mathf.Abs (playerDist) < 2) { //Working on a sword swing :Y
			Debug.Log ("close");
			swordAnim.SetInteger ("State", 1);
		} else {
			swordAnim.SetInteger ("State", 0);
		}

		if (playerDist < 0) { 			//Flips the enemy sprites to follow player
			enemySprite.flipX = true;
			swordSprite.flipX = true;  //note to self: Next time make sure sprites are facing the right way when importing XP
		} else {
			enemySprite.flipX = false;
			swordSprite.flipX = false;
		}




		Vector2 velocity = new Vector2 (Mathf.Clamp ((playerDist * speed),-maxSpeed,maxSpeed) + 2, 6); // the + 2 keeps the enemy from stopping when it reaches the player
		enemyRb.velocity = -velocity;

	}
}
