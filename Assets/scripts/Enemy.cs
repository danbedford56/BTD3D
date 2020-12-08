using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Attributes:")]
    public float speed = 10f;
    public float health = 20f;

    private Transform target;
    private int wayPointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(target.position, transform.position) <= 0.5f)
        {
            getNewWaypoint();
        }
    }

    void getNewWaypoint()
    {
        if (wayPointIndex == Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wayPointIndex++;
        target = Waypoints.points[wayPointIndex];
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}