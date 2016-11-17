using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

	private bool damagable; //Is the character out of invunerability frames?
	private float damageT; //when char. takes damage
	private SpriteRenderer spriteR; 
	private float damageRate; // How often can char. get hurt
	private bool damaging;

	public int health;
	public bool isEnemy;
	public Sprite spriteOrig;
	public Sprite spriteDamage;


	public void damage (int damageCount){
		health -= damageCount;
		damageT = Time.time;
		if (!isEnemy)
			damagable = false;
		if (health <= 0)
			Destroy (gameObject);

		spriteR.sprite = spriteDamage; 
	}

	void Start () {
		spriteR = GetComponent<SpriteRenderer> ();
		damagable = true; 
		damageT = 0f;
		damageRate = 1;
	}


	void Update () {
		if (Time.time > damageT + damageRate) {
			damagable = true;
			spriteR.sprite = spriteOrig; 
		}
	}

	void OnCollisionEnter2D (Collision2D col){
		if (damagable) {
			if (col.gameObject.CompareTag ("Enemy") && !isEnemy) {
				damage (1);
			}
			if (col.gameObject.CompareTag ("Projectile") && isEnemy) {
				if (damaging)
					damage (1);
			}
		}

	}


}
