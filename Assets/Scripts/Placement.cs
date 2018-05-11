using UnityEngine;
using UnityEngine.EventSystems;

public class Placement : MonoBehaviour {
	public Color hoverColor;
	private GameObject turret;
	public Vector3 OffsetPositionTurret1;
    public Vector3 OffsetPositionTurret2;
    public Vector3 OffsetPositionTurret3;

    private Renderer rend;
	private Color startColor;

    BuildManager buildManager;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
        buildManager = BuildManager.instance;
	}

	void OnMouseDown(){
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null) {
            return;
        }

		if (turret != null) {
			Debug.Log ("Can't build turret here");
			return;
		}

		GameObject turretToBuild = buildManager.GetTurretToBuild();
        if (buildManager.GetTurretToBuild() == buildManager.Turret1)
        {
            turret = (GameObject)Instantiate(turretToBuild, transform.position + OffsetPositionTurret1, transform.rotation);
        }

        if (buildManager.GetTurretToBuild() == buildManager.Turret2)
        {
            turret = (GameObject)Instantiate(turretToBuild, transform.position + OffsetPositionTurret2, transform.rotation);
        }

        if (buildManager.GetTurretToBuild() == buildManager.Turret3)
        {
            turret = (GameObject)Instantiate(turretToBuild, transform.position + OffsetPositionTurret3, transform.rotation);
        }
    }

	// Update is called once per frame
	void OnMouseEnter(){
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
	}

	void OnMouseExit(){
		rend.material.color = startColor;
	}
}
