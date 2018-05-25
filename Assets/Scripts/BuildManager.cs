using UnityEngine;

public class BuildManager : MonoBehaviour {
	public static BuildManager instance;

    public GameObject Turret1;
    public GameObject Turret2;
    public GameObject Turret3;

    void Awake(){
		if(instance != null){
			Debug.LogError ("Build Manager has multiple active");
			return;
		}
		instance = this;
	}

    TurretInfo turretInfo;
	private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Placement place) {

        if (PlayerStats.Money < turretToBuild.cost) {
            Debug.Log("Not Enough Money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        if (turretToBuild.prefabs == Turret1) { 
            GameObject turret = (GameObject)Instantiate(turretToBuild.prefabs, place.GetBuildPosition1(), Quaternion.identity);
            place.turret = turret;
        }

        if (turretToBuild.prefabs == Turret2)
        {
            GameObject turret = (GameObject)Instantiate(turretToBuild.prefabs, place.GetBuildPosition2(), Quaternion.identity);
            place.turret = turret;
        }

        if (turretToBuild.prefabs == Turret3)
        {
            GameObject turret = (GameObject)Instantiate(turretToBuild.prefabs, place.GetBuildPosition3(), Quaternion.identity);
            place.turret = turret;
        }

        Debug.Log(PlayerStats.Money);
    }


    public void SelectTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret;
    }
}
