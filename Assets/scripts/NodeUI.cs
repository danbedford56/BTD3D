using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public GameObject upgradeButton;
    private Node target;
    public TextMeshProUGUI towerTitle;
    public TextMeshProUGUI towerFireRate;
    public TextMeshProUGUI towerDamage;
    public TextMeshProUGUI towerRange;
    public TextMeshProUGUI sellAmount;
    public TextMeshProUGUI upgradeAmount;
    

    public void SetTarget(Node _target)
    {
        target = _target;
        Vector3 offset = new Vector3(0, 2, 0);
        transform.position = target.GetBuildPosition() + offset;

        tower towerStats = null;
        if (!target.isUpgraded)
        {
            upgradeAmount.text = "UPGRADE £" + target.towerBlueprint.upgradeCost;
            upgradeButton.SetActive(true);
            towerStats = target.tower.GetComponent<tower>();
        }
        else
        {
            upgradeButton.SetActive(false);
            towerStats = target.towerBlueprint.upgradedPrefab.GetComponent<tower>();
        }

        towerTitle.text = target.towerBlueprint.prefab.name;
        towerFireRate.text = "Fire rate: " + towerStats.fireRate + "/sec";
        towerDamage.text = "Damage: " + towerStats.damage;
        towerRange.text = "Range: " + towerStats.range + "m";
        sellAmount.text = "SELL £" + target.sellAmount;
       

        ui.SetActive(true);

    }

    public void Hide ()
    {
        ui.SetActive(false);
    }

    public void Sell()
    {
        target.SellTower();
        BuildManager.instance.DeselectNode();
    }

    public void Upgrade()
    {
        target.UpgradeTower();
        BuildManager.instance.DeselectNode();

    }
}
