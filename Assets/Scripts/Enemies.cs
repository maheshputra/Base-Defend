using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour {
    public float speed = 10f;
    public float starthealth = 100;
    public float health;

    public Transform partToMove;

    private Transform target;
    private int wavepointIndex = 0;

    public Image healthbar; 

    // Use this for initialization
    void Start()
    {
        target = Waypoints.points[0];
        health = starthealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        partToMove.transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoints();
        }
    }

    public void TakeDamage(int amount) {
        health -= amount;

        healthbar.fillAmount = health / starthealth;

        if (health <= 0)
        {
            Dies();
        }

    }

    void GetNextWaypoints()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];

    }

    void EndPath() {
        Destroy(gameObject);
        PlayerStats.Lives -= 10;
    }

    void Dies() {
        Destroy(gameObject);
    }

}
