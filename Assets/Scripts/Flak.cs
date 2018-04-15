using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flak : MonoBehaviour {

    private Transform target;
    [Header("Attributes")]
    public float range = 7f;
    public float fireRate = 1f;
    public float fireCountdown = 0;

    [Header("Unity Setup Fields")]
    public string enemyTag = "enemy";

    public bool idle;
    //private float speed = 15f;

    public Transform Head;

    public GameObject bulletPrefabs;
    public Transform firePoint;

    public float turnSpeed = 10f;

    // Use this for initialization
    void Start()
    {
        idle = true;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Head.Rotate(0, 0, turnSpeed * Time.deltaTime);
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(Head.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        Head.rotation = Quaternion.Euler(0, rotation.y, 0);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shotestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shotestDistance)
            {
                shotestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

            if (nearestEnemy != null && shotestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
