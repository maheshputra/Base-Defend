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

	public GameObject Turret1;
    public GameObject Turret2;
    public GameObject Turret3;

	private GameObject turretToBuild;

	public GameObject GetTurretToBuild(){
		return turretToBuild;
	}

    public void SetTurretToBuild(GameObject Turret) {
        turretToBuild = Turret;
    }
}
