using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject player;

	private Transform tf;
	private Vector3 bounds;
	private Vector3 playerPos;


	public float xMin, xMax, yMin, yMax;

	public float playerXDisplace; //how much elbow room should camera give player?
	public float playerYDisplace; //Same^


	void Start () {

		tf = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (player != null)
			playerPos = player.transform.position;
		
	}

	void LateUpdate()
	{
		//magic, do not touch
		Vector3 pos = new Vector3 (Mathf.Clamp (playerPos.x + playerXDisplace, xMin, xMax), Mathf.Clamp (playerPos.y + playerYDisplace, yMin, yMax), -10f);
		tf.position = pos;
	}

}
