using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Attributes:")]
    private Transform target;
    public float bulletSpeed = 80f;
    public float explosionRadius = 0f;

    [Header("Bullet Setup:")]
    public GameObject impactEffect;
    [SerializeField]
    private string enemyTag = "Enemy";

    [HideInInspector]
    public float damage;

    public void FindTarget(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.position - transform.position;
        float distanceOnUpdate = bulletSpeed * Time.deltaTime;

        if(direction.magnitude <= distanceOnUpdate)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceOnUpdate, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        if (effectInstance.GetComponent<AudioSource>())
        {
            effectInstance.GetComponent<AudioSource>().Play();
        }
        Destroy(effectInstance, 1f);

        if (explosionRadius > 0f)
        {
            // Explody stuff
            Explode();
        } else {
            // Non-explody stuff
            target.GetComponent<Enemy>().takeDamage(damage);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] collidersHit = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in collidersHit)
        {
            if (collider.tag == enemyTag)
            {
                collider.GetComponent<Enemy>().takeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
