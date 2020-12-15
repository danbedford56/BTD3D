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
    public Vector3 placementOffset;

    [Header("Setup")]
    public Transform firePoint;
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;
    public Transform rotationPoint;

    [Header("Gun")]
    public GameObject bulletPrefab;
    public AudioSource shotSound;

    [Header("Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;


    private float enemySpeed = 0f;

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
            if (target != null && enemySpeed > 0)
            {
                target.GetComponent<Enemy>().speed = enemySpeed;
            }
            enemySpeed = nearestEnemy.GetComponent<Enemy>().speed;
            target = nearestEnemy.transform;
        }
        else
        {
            if (target != null && enemySpeed > 0)
            {
                target.GetComponent<Enemy>().speed = enemySpeed;
            }
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                }
            }
            return;
        }

        LockOn();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOn()
    {
        // Match rotation
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotationPoint.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotationPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        LaserBeam();
        target.GetComponent<Enemy>().speed = 3f;
    }

    void LaserBeam()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void Shoot()
    {
        GameObject bulletToShoot = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletToShoot.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.damage = damage;
            bullet.FindTarget(target);
            if (shotSound)
            {
                shotSound.Play();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}