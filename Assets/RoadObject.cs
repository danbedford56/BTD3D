using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObject : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.GetComponent<Enemy>())
        {
            enemy.GetComponent<Enemy>().damageOverTime = 5;
        }
    }
}
