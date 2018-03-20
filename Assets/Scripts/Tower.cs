using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public bool idle;
    private float speed = 15f;
	// Use this for initialization
	void Start () {
        idle = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (idle) {
			transform.Rotate(0,0,speed*Time.deltaTime);
        }
	}
}