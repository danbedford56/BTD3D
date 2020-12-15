using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.GetComponent<Enemy>())
        {
            enemy.GetComponent<Enemy>().damageOverTime = 5;
        }
    }
}
