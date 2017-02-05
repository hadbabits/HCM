using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private Transform tf;
	private Vector3 bounds;
	private Vector3 playerPos;
	private GameObject player;

	public float xMin, xMax, yMin, yMax;

	public float playerXDisplace; //how much elbow room should camera give player?


	void Start () {

		tf = GetComponent<Transform> ();
		player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {

		playerPos = player.transform.position;
		
	}

	void LateUpdate()
	{
		//magic, do not touch
		Vector3 pos = new Vector3 (Mathf.Clamp (playerPos.x + playerXDisplace, xMin, xMax), Mathf.Clamp (playerPos.y +2, yMin, yMax), -10f);
		tf.position = pos;
	}

}
