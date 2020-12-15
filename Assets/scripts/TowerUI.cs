using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 


public class TowerUI : MonoBehaviour
{
    [Header("isOptional")]
    public TextMeshProUGUI towerCostText;
    public TowerBlueprint tower;
    public TextMeshProUGUI towerUnlockText;
    public GameObject towerUnlockPanel;
    private Button placeTowerButton; 

    void Start()
    {
        placeTowerButton = GetComponent<Button>();
        towerCostText.text = "£" + tower.cost.ToString();

        
        towerUnlockText.text = "Unlock Tower at Round " + tower.unlockAtLevel.ToString();
        towerUnlockPanel.gameObject.SetActive(true);
        placeTowerButton.interactable = false;
    }

    void Update()
    {
        if ((RoundSystem.currentRound + 1) >= tower.unlockAtLevel)
        {
            towerUnlockPanel.gameObject.SetActive(false);
            placeTowerButton.interactable = true;
        }
    }
}
