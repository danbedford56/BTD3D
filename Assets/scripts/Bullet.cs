using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float bulletSpeed = 80f;
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
    }

    void HitTarget()
    {
        target.GetComponent<Enemy>().takeDamage(damage);
        Destroy(gameObject);
    }
}
