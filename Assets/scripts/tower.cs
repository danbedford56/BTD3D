using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{

    private Transform target;

    [Header("Turret Attributes")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float range;
    public float damage;
    [Header("Setup")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;
    public Transform rotationPoint;
    public AudioClip towerAudio;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;
        float smallestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && smallestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        // Match rotation
        Vector3 direction = target.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotationPoint.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //rotation.y += 180;
        rotationPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //Firing
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;

        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletToShoot = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletToShoot.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.damage = damage;
            bullet.FindTarget(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
