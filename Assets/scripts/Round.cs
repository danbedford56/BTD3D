using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Round : ScriptableObject
{ 
    public Wave[] waves;
    public float timeBetweenWaves = 5f;

}

[System.Serializable]
public struct Wave
{
    public GameObject[] enemies;
    public int[] numOfEnemies;
}