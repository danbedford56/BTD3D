using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class TowerBlueprint : ScriptableObject
{
    public GameObject prefab;
    public GameObject upgradedPrefab;
    public int cost;
    public int unlockAtLevel;
    public int upgradeCost;

    //These variables are set in the shop in unity. 
    public int sellAmount
    {
        get
        {
            return cost / 2;
        }
    }

    

}
