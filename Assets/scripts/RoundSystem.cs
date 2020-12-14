using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArrayExtensions;
using UnityEngine.UI; 

public class RoundSystem : MonoBehaviour
{
    public Round[] rounds;
    public Transform spawnPoint;
    public static int currentRound = 0;
    public static bool roundOngoing = false;
    private static float countdown = 2f;
    private int currentWave = 0;
    public static int enemiesAlive = 0;
    public Button startRoundButton;
    public GameObject shopPanel; 

    public void startRound()
    {

        if (currentRound < rounds.Length)
        {
            Debug.Log("Round " + currentRound + " started");
            roundOngoing = true;
            startRoundButton.gameObject.SetActive(false);
            shopPanel.gameObject.SetActive(false);
            BuildManager.instance.SelectTowerToBuild(null);
        }

    }

    private void Update()
    {
        if (roundOngoing)
        {
            if (countdown <= 0f)
            {
                if (currentWave >= rounds[currentRound].waves.Length)
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
        }else
        {
            startRoundButton.gameObject.SetActive(true);
            shopPanel.gameObject.SetActive(true);
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
            PlayerStatus.Rounds++;
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

