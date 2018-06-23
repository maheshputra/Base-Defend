using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {
    public Transform PartRotate;

	void Update () {
        PartRotate.Rotate(0, 0, 80 * Time.deltaTime);
    }
}
