using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
	public static BuildManager instance;

	void Awake(){
		if(instance != null){
			Debug.LogError ("Build Manager has multiple active");
			return;
		}
		instance = this;
	}

	public GameObject standartTurretPrefab;

	void Start(){
		turretToBuild = standartTurretPrefab;
	}

	private GameObject turretToBuild;

	public GameObject GetTurretToBuild(){
		return turretToBuild;
	}
}
