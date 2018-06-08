using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    public Transform Cincin1;
    public Transform Cincin2;


   
    // Use this for initialization
    void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
       Cincin1.Rotate( 20 * Time.deltaTime, 0, 0);
       Cincin2.Rotate( -30* Time.deltaTime, 0, 0);
    }
}
