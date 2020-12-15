using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [Header("Enemy Attributes:")]
    public float speed = 10f;
    public float health = 20f;
    public int moneesOnDeath = 20;

    public int damageOverTime = 0;
    private float damageOverTimeCountdown = 5f;

    private Transform target;
    private int wayPointIndex = 0;
    private bool isDead = false;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(target.position, transform.position) <= 0.8f)
        {
            getNewWaypoint();
        }

        if (damageOverTimeCountdown <= 0) { takeDamage(damageOverTime); damageOverTimeCountdown = 5f; }

        damageOverTimeCountdown -= Time.deltaTime;
    }

    void getNewWaypoint()
    {
        if (wayPointIndex == Waypoints.points.Length - 1)
        {
            RoundSystem.enemiesAlive--;
            PlayerStatus.lives -= health;
            
            Destroy(gameObject);
            return;
        }

        wayPointIndex++;
        target = Waypoints.points[wayPointIndex];
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        //Debug.Log(RoundSystem.enemiesAlive + " and one just died");
        Destroy(gameObject);
        PlayerStatus.monees += moneesOnDeath;
        RoundSystem.enemiesAlive--;
        Debug.Log(PlayerStatus.monees);
    }

    

}