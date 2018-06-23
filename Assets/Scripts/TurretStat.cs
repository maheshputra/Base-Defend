using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretStat : MonoBehaviour {


    public Text TurName;
    public Text TurCost;
    public Text TurDmg;
    public Text TurSpd;
    public Text TurRange;


    void Start () {
        TurName.text = "---";
        TurCost.text = "$--";
        TurDmg.text = "-";
        TurSpd.text = "-";
        TurRange.text = "-";
    }
	

    public void SelectTurret1(){
        TurName.text = "Turret 1";
        TurCost.text = "$100";
        TurDmg.text = "350";
        TurSpd.text = "50";
        TurRange.text = "1000";
    }

    public void SelectTurret2()
    {
        TurName.text = "Turret 2";
        TurCost.text = "$250";
        TurDmg.text = "200";
        TurSpd.text = "150";
        TurRange.text = "700";
    }

    public void SelectTurret3()
    {
        TurName.text = "Turret 3";
        TurCost.text = "$450";
        TurDmg.text = "2000";
        TurSpd.text = "20";
        TurRange.text = "1500";
    }

}
