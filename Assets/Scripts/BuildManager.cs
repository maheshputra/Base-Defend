using UnityEngine;

public class BuildManager : MonoBehaviour {
	public static BuildManager instance;

    private Placement selectedNode;
    public NodeUI nodeUI;

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


    public void SelectNode(Placement node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		turretToBuild = null;

		nodeUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}



    public void SelectTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret;

        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild() {
        return turretToBuild;
    }

}
