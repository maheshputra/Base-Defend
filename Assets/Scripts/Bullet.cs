using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;
    public int damage = 20;
    public float explosionRadius = 0;
	//public GameObject impactEffect;

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
        //GameObject effectIns = Instantiate (impactEffect, transform.position, transform.rotation);
        //Destroy (effectIns, 2f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else {
            Damage(target);
        }
     
        Destroy(gameObject);
	}

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position,explosionRadius);
        foreach (Collider collider in colliders)
        {   
            if (collider.tag == "enemy") {
                Damage(collider.transform);
                Debug.Log("Explode");
            }
        }
    }

    void Damage(Transform enemy) {
        Enemies e = enemy.GetComponent<Enemies>();
        Boss b = enemy.GetComponent<Boss>();

        if (e != null) { 
            e.TakeDamage(damage);
        }

        if (b != null) {
            b.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
