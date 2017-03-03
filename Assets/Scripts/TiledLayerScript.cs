using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiled2Unity;

public class TiledLayerScript : MonoBehaviour {

	public PhysicsMaterial2D slip; //no friction material

	private GameObject colChild; //collider child
	private GameObject meshChild;
	private Renderer rend; 
	private string pTag; //parent tag (technically parent to the above child, so this game object. Whatever)
	private string sLayer; //sorting layer

	void Start () {

		colChild = this.transform.Find ("Collision").gameObject;
		meshChild = this.transform.GetChild (0).gameObject; //Mesh child object's name will differ depending on texture used. 
		rend = meshChild.GetComponent<Renderer> ();

		pTag = this.gameObject.tag;
		sLayer = rend.sortingLayerName;//workaround until I can figure out custom properties in Tiled



		if (!this.CompareTag ("Untagged"))
			colChild.tag = pTag;

		if (sLayer == "Midground")
			colChild.GetComponent<PolygonCollider2D> ().sharedMaterial = slip; //sloppy, but it'll do for now
			
	}
	

	void Update () {
		
	}
}
