using UnityEngine;

public class TurretInfo : MonoBehaviour {

    BuildManager buildManager;

	void Start () {
        buildManager = BuildManager.instance;
	}

    public void PurcaseTurret1() {
        Debug.Log("Turret 1");
        buildManager.SetTurretToBuild(buildManager.Turret1);
    }

    public void PurcaseTurret2()
    {
        Debug.Log("Turret 2");
        buildManager.SetTurretToBuild(buildManager.Turret2);
    }

    public void PurcaseTurret3()
    {
        Debug.Log("Turret 3");
        buildManager.SetTurretToBuild(buildManager.Turret3);
    }

}
