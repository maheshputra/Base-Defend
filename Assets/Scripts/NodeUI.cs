using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject ui;

    public Text UpgradeCost;
    public Text SellCost;


    private Placement target;


    public void SetTarget(Placement _target)
	{
		target = _target;

		transform.position = target.GetBuildPositionUI();
        UpgradeCost.text = "$" + target.TurretBlueprint.upgradeCost;
        SellCost.text = "$" + target.TurretBlueprint.sellCost;

        ui.SetActive(true);
	}

	public void Hide()
	{
		ui.SetActive(false);
	}

    public void Upgrade() {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
