using UnityEngine;
using UnityEngine.EventSystems;

public class Placement : MonoBehaviour {
	public Color hoverColor;
    public Vector3 OffsetPositionTurret1;
    public Vector3 OffsetPositionTurret2;
    public Vector3 OffsetPositionTurret3;

    [Header("Optional")]
    public GameObject turret;
	
    private Renderer rend;
	private Color startColor;

    BuildManager buildManager;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
        buildManager = BuildManager.instance;
	}

    public Vector3 GetBuildPosition1() {
        Debug.Log("Turret1");
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

        if (!buildManager.CanBuild) {
            return;
        }

		if (turret != null) {
			Debug.Log ("Can't build turret here");
			return;
		}

        buildManager.BuildTurretOn(this);
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
