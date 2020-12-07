using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Round roundOne;
    public Transform spawnPoint;
    private float countdown = 2f;
    private int waveIndex = 0;  
    
    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = roundOne.timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(roundOne.enemies[0], spawnPoint.position, spawnPoint.rotation);
    }


}
