using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TowerBlueprint towerToBuild;
    

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


    //Set the tower we want to build as the tower we give it. 
    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower; 
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
    public void BuildTowerOn(Node node)
    {
        if (PlayerStatus.monees < towerToBuild.cost)
        {
            Debug.Log("Let player know on UI that they have insufficient monees");
            return;
        }

        PlayerStatus.monees -= towerToBuild.cost;
        Vector3 offset = towerToBuild.prefab.GetComponent<tower>().placementOffset;
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, node.GetBuildPosition() + offset, Quaternion.identity);
        node.tower = tower;
        Debug.Log("Tower built! Money left!" + PlayerStatus.monees);
    }

}
