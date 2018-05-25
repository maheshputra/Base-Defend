using UnityEngine;

public class TurretInfo : MonoBehaviour {

    public TurretBlueprint turret1;
    public TurretBlueprint turret2;
    public TurretBlueprint turret3;

    public int TowerIdentity;

    BuildManager buildManager;

	void Start () {
        buildManager = BuildManager.instance;
	}

    public void SelectTurret1() {
       // Debug.Log("Turret 1");
        buildManager.SelectTurretToBuild(turret1);
    }

    public void SelectTurret2()
    {
       // Debug.Log("Turret 2");
        buildManager.SelectTurretToBuild(turret2);
    }

    public void SelectTurret3()
    {
       //    Debug.Log("Turret 3");
        buildManager.SelectTurretToBuild(turret3);
    }

}
