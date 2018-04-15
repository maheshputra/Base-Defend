using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour {
	public Color hoverColor;
	private GameObject turret;
	public Vector3 OffsetPosition;

	private Renderer rend;
	private Color startColor;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

	void OnMouseDown(){
		if (turret != null) {
			Debug.Log ("Can't build turret here");
			return;
		}

		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position + OffsetPosition, transform.rotation);
	}

	// Update is called once per frame
	void OnMouseEnter(){
		rend.material.color = hoverColor;
	}

	void OnMouseExit(){
		rend.material.color = startColor;
	}
}
