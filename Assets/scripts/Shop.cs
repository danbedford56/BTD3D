
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TowerBlueprint turret; //We need to make a new TowerBlueprint variable for each tower. 

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    
    //This sets the tower that we want to build to a turret.
    //One of these is required for each tower we make. 
    public void SelectTurret()
    {
        Debug.Log("Turret selected");
        buildManager.SelectTowerToBuild(turret);
    }

}
