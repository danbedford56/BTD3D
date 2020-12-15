using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneesColor;
    public GameObject insufficientMoneeys;
    private Transform uiCanvas;

    [HideInInspector]
    public GameObject tower;
    public GameObject nature;
    [HideInInspector]
    public TowerBlueprint towerBlueprint;
    [HideInInspector]
    public Material rangeCircleMaterial;
    [HideInInspector]
    public bool isUpgraded;
    private bool isRoadTower = false;

    BuildManager buildManager;
    
    private Color startColor;
    private Renderer rend;

    public int sellAmount {
        get {
            if (isUpgraded)
            {
                return towerBlueprint.GetSellAmount() + (towerBlueprint.upgradeCost / 2);
            }
            else
            {
                return towerBlueprint.GetSellAmount();
            }
        }
    }
    //On start, make a new instance of build manager.
    //Sets the starting node color to the color set in Unity. 
    void Start()  
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        uiCanvas = GameObject.FindGameObjectWithTag("UI").transform;
    }

    public void SellTower()
    {
        PlayerStatus.monees += sellAmount;
        Debug.Log("sold for " + sellAmount);
        Vector3 offset = towerBlueprint.prefab.GetComponent<tower>().placementOffset;
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition() + offset, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(tower);
        towerBlueprint = null;
    }

    public void InsufficientMoney()
    {
        Vector3 position = new Vector3(900f, 1081f, 0f);
        Quaternion rot = new Quaternion(0, 0, 0, 0);
        GameObject text = (GameObject)Instantiate(insufficientMoneeys, position, rot, uiCanvas);
        Destroy(text, 3f);
    }

    public void UpgradeTower()
    {
        if (PlayerStatus.monees < towerBlueprint.upgradeCost)
        {
            InsufficientMoney();
            Debug.Log("Let player know on UI that they have insufficient monees to upgrade");
            return;
        }

        PlayerStatus.monees -= towerBlueprint.upgradeCost;
        Vector3 offset = towerBlueprint.prefab.GetComponent<tower>().placementOffset;

        //remove old one
        Destroy(tower);

        GameObject _tower = (GameObject)Instantiate(towerBlueprint.upgradedPrefab, GetBuildPosition() + offset, Quaternion.identity);
        tower = _tower;

        //build new one
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition() + offset, Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Destroy(this.GetComponent<LineRenderer>());
        Debug.Log("Tower upgraded! Money left!" + PlayerStatus.monees);
    }

    public void DestroyNature()
    {
        nature.GetComponent<Nature>().DestroyNature();
        Destroy(nature);
        nature = null;

    }

    //When the user hovers over a node, it there isnt a tower there, it will display a hover color. 
    void OnMouseEnter()
    {
        tower towerCom = null;
        if (!buildManager.CanBuild) { return; }
       
        if (buildManager.GetTowerToBuild().prefab.GetComponent<tower>())
        {
            towerCom = buildManager.GetTowerToBuild().prefab.GetComponent<tower>();
            isRoadTower = false;
            RangeTowerCheck(towerCom);
        }
        if (towerCom == null)
        {
            isRoadTower = true;
            RoadTowerCheck();
        }
    }

    void RoadTowerCheck()
    {
        if (!RoundSystem.roundOngoing)
        {
            if (!CheckForRoads())
            {
                rend.material.color = notEnoughMoneesColor;
            }
            else if (tower == null && nature == null)
            {
                rend.material.color = hoverColor;
            }
        }
    }

    void RangeTowerCheck(tower towerCom)
    {
        if (!RoundSystem.roundOngoing)
        {
            if (!buildManager.HasMonees || nature)
            {
                rend.material.color = notEnoughMoneesColor;
            }
            else if (tower == null && nature == null)
            {
                Draw.DrawCircle(gameObject, towerCom.range);
                rend.material.color = hoverColor;
            }
            
        }
    }

    private enum roadDirection { Left, Right, Up, Down}
    private roadDirection currentRoadDirection = roadDirection.Down;

    bool CheckForRoads()
    {
        bool roadTowerCanPlace = false;
        RaycastHit ray;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out ray, 5f))
        {
            if (ray.collider.tag == "Road")
            {
                roadTowerCanPlace = true;
                currentRoadDirection = roadDirection.Up;
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out ray, 5f))
        {
            if (ray.collider.tag == "Road")
            {
                roadTowerCanPlace = true;
                currentRoadDirection = roadDirection.Left;
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out ray, 5f))
        {
            if (ray.collider.tag == "Road")
            {
                roadTowerCanPlace = true;
                currentRoadDirection = roadDirection.Down;
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out ray, 5f))
        {
            if (ray.collider.tag == "Road")
            {
                roadTowerCanPlace = true;
                currentRoadDirection = roadDirection.Right;
            }
        }
        return roadTowerCanPlace;
    }


    //When the user stops hovering over a node, the color of the node is set back to the default color. 
    void OnMouseExit()
    { 
        if (buildManager.GetTowerToBuild() != null)
        {
            Destroy(this.GetComponent<LineRenderer>());
        }
        rend.material.color = startColor;
    }


    //When the user clicks on a node, if there is not a tower there already, and there is a tower selected to place, it places a tower on the node. 
    void OnMouseDown()
    {

        if (!RoundSystem.roundOngoing)
        {
            if (tower != null || nature != null)
            {
                buildManager.SelectNode(this);
                return; 
            }

            if (isRoadTower)
            {
                if (!CheckForRoads())
                    return;
            } else
            {
                if (!buildManager.CanBuild)
                    return;
            }

            BuildTower(buildManager.GetTowerToBuild());
   
            buildManager.SelectTowerToBuild(null);
        }
    }

    void BuildTower (TowerBlueprint blueprint)
    {
        
        if (PlayerStatus.monees < blueprint.cost)
        {
            InsufficientMoney();
            return;
        }

        PlayerStatus.monees -= blueprint.cost;
        Vector3 offset = Vector3.zero;

        if (blueprint.prefab.GetComponent<tower>())
        {
            offset = blueprint.prefab.GetComponent<tower>().placementOffset;
        } else
        {
            offset = blueprint.prefab.GetComponent<Sanitizer>().placementOffset;
        }
        Quaternion towerRot = Quaternion.identity;
        if (isRoadTower)
        {
            towerRot = FindTowerRotation();
        }

        GameObject _tower = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition() + offset, towerRot);
        tower = _tower;
        towerBlueprint = blueprint;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect,GetBuildPosition() + offset, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(this.GetComponent<LineRenderer>());
    }

    Quaternion FindTowerRotation()
    {
        switch (currentRoadDirection)
        {
            case roadDirection.Up:
            {
                print("its up");
                return new Quaternion(0, 90, 0, 90);
            }
            case roadDirection.Down:
            {
                return new Quaternion(0, -90, 0, 90);
            }
            case roadDirection.Left:
            {
                return Quaternion.identity;
            }
            case roadDirection.Right:
            {
                return new Quaternion(0, 180, 0, 0);
            }
            default:
            {
                return Quaternion.identity;
            }
        }
    }

    //This sets the build position to the node position plus the tower offset which is the distance above the node. 
    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }


}
