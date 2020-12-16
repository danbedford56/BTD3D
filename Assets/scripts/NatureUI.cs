using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NatureUI : MonoBehaviour
{
    public GameObject ui;
    [HideInInspector]
    public Node target;

    public TextMeshProUGUI destroyCostText;

    public void SetTarget(Node _target)
    {
        target = _target;
        Vector3 offset = new Vector3(7, 4, -4);
        transform.position = target.GetBuildPosition() + offset;

        if (target.nature)
        {
            destroyCostText.text = "Destroy: £" + target.nature.GetComponent<Nature>().costToDestroy; 
        }

        ui.SetActive(true);

    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Sell()
    {
        int natureCost = target.nature.GetComponent<Nature>().costToDestroy;
        if (PlayerStatus.monees >= natureCost)
        {
            target.DestroyNature();
        }
        BuildManager.instance.DeselectNode();
    }
}
