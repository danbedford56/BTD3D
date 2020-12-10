using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;
    public Text sellAmount;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();
        sellAmount.text = "SELL £" + target.towerBlueprint.GetSellAmount();
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
}
