using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Round : ScriptableObject
{
    public int numOfWaves;
    public GameObject[] enemies;
    public float timeBetweenWaves = 5f;

}
