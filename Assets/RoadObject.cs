using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObject : MonoBehaviour
{
    private float sanitiserCountdown = 5f;

    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            if (sanitiserCountdown <= 0f)
            {
                this.gameObject.SetActive(false);
                sanitiserCountdown = 5f;
            }
            sanitiserCountdown -= Time.deltaTime;
        }
    }
    
    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.GetComponent<Enemy>())
        {
            enemy.GetComponent<Enemy>().damageOverTime = 5;
        }
    }
}
