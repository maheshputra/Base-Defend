using UnityEngine;
using UnityEngine.EventSystems;

public class Placement : MonoBehaviour {
    public Color hoverColor;
    public Vector3 OffsetNodeUI;
    public Vector3 OffsetPositionTurret1;
    public Vector3 OffsetPositionTurret2;
    public Vector3 OffsetPositionTurret3;

    [Header("Turret")]
    public GameObject Turret1;
    public GameObject Turret2;
    public GameObject Turret3;

    public GameObject Turret1Up;
    public GameObject Turret2Up;
    public GameObject Turret3Up;


    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint TurretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
	private Color startColor;

    BuildManager buildManager;
    

    // Use this for initialization
    void Start () {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
        buildManager = BuildManager.instance;
	}
        
    public Vector3 GetBuildPositionUI()
    {
        return transform.position + OffsetNodeUI;

    }

    public Vector3 GetBuildPosition1() {
        return transform.position + OffsetPositionTurret1;
        
    }

    public Vector3 GetBuildPosition2()
    {
        return transform.position + OffsetPositionTurret2;
    }

    public Vector3 GetBuildPosition3()
    {
        return transform.position + OffsetPositionTurret3;
    }


    void OnMouseDown(){
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


		if (turret != null) {
			Debug.Log ("Can't build turret here");
            buildManager.SelectNode(this);
			return;
		}

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not Enough Money");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        if (blueprint.prefabs == Turret1)
        {
            GameObject _turret = (GameObject)Instantiate(blueprint.prefabs, GetBuildPosition1(), Quaternion.identity);
            turret = _turret;
        }

        if (blueprint.prefabs == Turret2)
        {
            GameObject _turret = (GameObject)Instantiate(blueprint.prefabs, GetBuildPosition2(), Quaternion.identity);
            turret = _turret;
        }

        if (blueprint.prefabs == Turret3)
        {
            GameObject _turret = (GameObject)Instantiate(blueprint.prefabs, GetBuildPosition3(), Quaternion.identity);
            turret = _turret;
        }

        TurretBlueprint = blueprint;

        Debug.Log(PlayerStats.Money);
    }

    public void UpgradeTurret() {
        if (PlayerStats.Money < TurretBlueprint.upgradeCost)
        {
            Debug.Log("Not Enough Money");
            return;
        }

        PlayerStats.Money -= TurretBlueprint.upgradeCost;

        Destroy(turret);

        if (TurretBlueprint.upgradedPrefabs == Turret1Up)
        {
            GameObject _turret = (GameObject)Instantiate(TurretBlueprint.upgradedPrefabs, GetBuildPosition1(), Quaternion.identity);
            turret = _turret;
        }

        if (TurretBlueprint.upgradedPrefabs == Turret2Up)
        {
            GameObject _turret = (GameObject)Instantiate(TurretBlueprint.upgradedPrefabs, GetBuildPosition2(), Quaternion.identity);
            turret = _turret;
        }

        if (TurretBlueprint.upgradedPrefabs == Turret3Up)
        {
            GameObject _turret = (GameObject)Instantiate(TurretBlueprint.upgradedPrefabs, GetBuildPosition3(), Quaternion.identity);
            turret = _turret;
        }

        isUpgraded = true;

        Debug.Log(PlayerStats.Money);
    }

    void OnMouseEnter(){
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        rend.material.color = hoverColor;
	}

	void OnMouseExit(){
		rend.material.color = startColor;
	}
}
