using System.Collections;
using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
    public GameObject prefab;
    public int cost;

    //These variables are set in the shop in unity. 
    public int GetSellAmount()
    {
        return cost / 2;
    }
}
