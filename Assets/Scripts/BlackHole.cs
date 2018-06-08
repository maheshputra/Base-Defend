using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    public Transform Ring1;
    public Transform Ring2;

    // Update is called once per frame
    void Update () {

        Ring1.Rotate(0, 0, 10 * Time.deltaTime);
        Ring2.Rotate(0, 0, -15 * Time.deltaTime);

    }
}
