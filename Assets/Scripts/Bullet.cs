using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	public GameObject impactEffect;

	public float bulletSpeed = 70f;

	public void Seek (Transform _target){
		target = _target;
	} 

	void Update(){
		if (target == null) {
			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = bulletSpeed * Time.deltaTime;

		if(dir.magnitude <= distanceThisFrame){
			HitTarget ();
			return;
		}

		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
	}

	public void HitTarget(){
		GameObject effectIns = Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (effectIns, 2f);

		Destroy (target.gameObject);
		Destroy (gameObject);
	}
}
