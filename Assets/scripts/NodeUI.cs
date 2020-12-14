using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public GameObject upgradeButton;
    private Node target;
    public Text sellAmount;
    public Text upgradeAmount;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (target.nature)
        {
            sellAmount.text = "Destroy £" + target.nature.GetComponent<Nature>().costToDestroy;
            upgradeButton.SetActive(false);
        }
        else if (target.tower)
        {
            sellAmount.text = "SELL £" + target.sellAmount;

            if (!target.isUpgraded)
            {
                upgradeAmount.text = "UPGRADE £" + target.towerBlueprint.upgradeCost;
                upgradeButton.SetActive(true);
            }
            else
            {
                upgradeButton.SetActive(false);
            }
        }

        ui.SetActive(true);

    }

    public void Hide ()
    {
        ui.SetActive(false);
    }

    public void Sell()
    {
        if (target.nature)
        {
            int natureCost = target.nature.GetComponent<Nature>().costToDestroy;
            if (PlayerStatus.monees >= natureCost)
            {
                target.DestroyNature();
            }
        }
        else if (target.tower)
        {
            target.SellTower();
        }
        BuildManager.instance.DeselectNode();
    }

    public void Upgrade()
    {
        target.UpgradeTower();
        BuildManager.instance.DeselectNode();

    }
}
