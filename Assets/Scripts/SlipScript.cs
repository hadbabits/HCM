using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipScript : MonoBehaviour {

	public PhysicsMaterial2D slipMat;

	private PolygonCollider2D pCol;

	void Start () {
		if (pCol == null)
			pCol = GetComponent<PolygonCollider2D> ();

		pCol.sharedMaterial = slipMat;
	}
	


}
