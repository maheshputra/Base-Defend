using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint {

    public GameObject prefabs;
    public int cost;

    public GameObject upgradedPrefabs;
    public int upgradeCost;

    public int sellAmount() {
        return cost / 2;
    }

    public int sellAmountUpgraded() {
        return upgradeCost / 2;
    }

    
}
