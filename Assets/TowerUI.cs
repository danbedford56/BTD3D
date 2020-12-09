using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TowerUI : MonoBehaviour
{
    [Header("isOptional")]
    public TextMeshProUGUI towerCostText;
    public TowerBlueprint tower;

    void Awake()
    {
        towerCostText = GetComponent<TextMeshProUGUI>();
        towerCostText.text = "£" + tower.cost.ToString();
    }
}
