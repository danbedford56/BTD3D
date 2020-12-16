using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TowerBlueprint towerToBuild;
    private Node selectedNode;
    public GameObject buildEffect;
    public GameObject sellEffect;
    public NodeUI nodeUI;
    public NatureUI natureUI;

    //When the game starts, if there is already a BuildManager instance, there is a message in the console log. 
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("There is already a BuildManager");
            return;
        }
        instance = this;
    }

    public void SelectNode(Node node)
    {
        if (selectedNode)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        if (node.tower != null) {
            tower towerCom = node.tower.GetComponent<tower>();
            Draw.DrawCircle(node.gameObject, towerCom.range);
        }
        towerToBuild = null;
        if (node.nature)
        {
            natureUI.SetTarget(node);
        } else if (node.tower)
        {
            nodeUI.SetTarget(node);
        }
    }

    public void DeselectNode()
    {
        if (selectedNode)
        {
            if (selectedNode.GetComponent<LineRenderer>())
            {
                Destroy(selectedNode.GetComponent<LineRenderer>());
            }
            selectedNode = null;
            nodeUI.Hide();
            natureUI.Hide();
        }
    }
    //Set the tower we want to build as the tower we give it. 
    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        DeselectNode();
    }


    //This function determins whether the space is free to build on. 
    public bool CanBuild
    {
        get
        {
            return towerToBuild != null;
        }
    }


    //Sets the tower position as the build position and sets the node tower to the given tower.
    //If the player doesnt have enough money, they wont be able to build the tower. 

    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }

    public bool HasMonees
    {
        get
        {
            return PlayerStatus.monees >= towerToBuild.cost;
        }
    }
}