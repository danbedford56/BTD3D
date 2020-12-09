using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArrayExtensions;

public class RoundSystem : MonoBehaviour
{
    public Round[] rounds;
    public Transform spawnPoint;
    private int currentRound = 0;
    public static bool roundOngoing = false;
    private static float countdown = 2f;
    private int currentWave = 0;
    public static int enemiesAlive = 0;

    public void startRound()
    {
        Debug.Log("Round " + currentRound + " started");
        roundOngoing = true;
    }

    private void Update()
    {
        if (roundOngoing)
        {
            if (countdown <= 0f)
            {
                if (currentWave == rounds[currentRound].waves.Length)
                {
                    //StopCoroutine(SpawnWave());
                    if (enemiesAlive == 0)
                    {
                        Debug.Log("Round finished");
                        roundOngoing = false;
                        currentWave = 0;
                        currentRound++;
                    }
                } else {
                    StartCoroutine(SpawnWave());
                    countdown = rounds[currentRound].timeBetweenWaves;
                }
            }
            countdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave()
    {
        Debug.Log(currentWave);
        if (currentWave < rounds[currentRound].waves.Length)
        {
            List<GameObject> wave = createWaveArray(rounds[currentRound].waves[currentWave]);

            for (int i = 0; i < wave.Count; i++)
            {
                SpawnEnemy(wave[i]);
                enemiesAlive++;
                Debug.Log(enemiesAlive + "Enemies alive");
                yield return new WaitForSeconds(0.5f);
            }
            currentWave++;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }


    List<GameObject> createWaveArray(Wave wave)
    {
        List<GameObject> enemies = new List<GameObject>();
        for (int j = 0; j < wave.enemies.Length; j++)
        {
            for(int i = 0; i < wave.numOfEnemies[j]; i++)
            {
                enemies.Add(wave.enemies[j]);
            }
        }
        enemies = enemies.Shuffle();
        return enemies;
    }

    

}

