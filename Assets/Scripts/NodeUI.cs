using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject ui;

    public Text UpgradeCost;
    public Button upgradeButton;

    public Text SellCost;


    private Placement target;


    public void SetTarget(Placement _target)
	{
		target = _target;

		transform.position = target.GetBuildPositionUI();

        if (!target.isUpgraded) {
            UpgradeCost.text = "$" + target.TurretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
            SellCost.text = "$" + target.TurretBlueprint.sellAmount();
        }
        else
        {
            UpgradeCost.text = "-";
            upgradeButton.interactable = false;
            SellCost.text = "$" + target.TurretBlueprint.sellAmountUpgraded();
        }
        
        

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

    public void Sell() {
        if (!target.isUpgraded)
        {
            target.SellTurret();
        }
        else
        {
            target.SellTurretUpgraded();
        }
        BuildManager.instance.DeselectNode();
    }
}
