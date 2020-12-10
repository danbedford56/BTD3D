using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneesColor;

    [Header("isOptional")]
    public GameObject tower;
    [HideInInspector]
    public TowerBlueprint towerBlueprint;

    BuildManager buildManager;
    
    private Color startColor;
    private Renderer rend;

    //On start, make a new instance of build manager.
    //Sets the starting node color to the color set in Unity. 
    void Start()  
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public void SellTower()
    {
        PlayerStatus.monees += towerBlueprint.GetSellAmount();
        Debug.Log("sold for " + towerBlueprint.GetSellAmount());
        Vector3 offset = towerBlueprint.prefab.GetComponent<tower>().placementOffset;
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition() + offset, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(tower);
        towerBlueprint = null;
    }

    //When the user hovers over a node, it there isnt a tower there, it will display a hover color. 
    void OnMouseEnter()
    {
        if (!RoundSystem.roundOngoing)
        {
            if (!buildManager.CanBuild)
                return;

            if (!buildManager.HasMonees)
            {
                rend.material.color = notEnoughMoneesColor;
            }
            else
            {
                rend.material.color = hoverColor;
            }
        }
    }


    //When the user stops hovering over a node, the color of the node is set back to the default color. 
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }


    //When the user clicks on a node, if there is not a tower there already, and there is a tower selected to place, it places a tower on the node. 
    void OnMouseDown()
    {

        if (!RoundSystem.roundOngoing)
        {
            if (tower != null)
            {
            buildManager.SelectNode(this);
            return; 
            }
            if (!buildManager.CanBuild)
                return;

            BuildTower(buildManager.GetTowerToBuild());
   
            buildManager.SelectTowerToBuild(null);
        }
    }

    void BuildTower (TowerBlueprint blueprint)
    {
        
        if (PlayerStatus.monees < blueprint.cost)
        {
            Debug.Log("Let player know on UI that they have insufficient monees");
            return;
        }

        PlayerStatus.monees -= blueprint.cost;
        Vector3 offset = blueprint.prefab.GetComponent<tower>().placementOffset;

        GameObject _tower = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition() + offset, Quaternion.identity);
        tower = _tower;
        towerBlueprint = blueprint;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect,GetBuildPosition() + offset, Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Tower built! Money left!" + PlayerStatus.monees);
        
    }
    //This sets the build position to the node position plus the tower offset which is the distance above the node. 
    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }


}
