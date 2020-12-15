
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TowerBlueprint turret; //We need to make a new TowerBlueprint variable for each tower. 
    public TowerBlueprint missileLauncher;
    public TowerBlueprint laser;
    public TowerBlueprint plagueDoctor;
    public TowerBlueprint handSanitizer; 

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

    public void SelectMissileLauncher()
    {
        Debug.Log("Launcher selected");
        buildManager.SelectTowerToBuild(missileLauncher);
    }

    public void SelectLaser()
    {
        Debug.Log("Laser selected");
        buildManager.SelectTowerToBuild(laser);
    }

    public void SelectPlagueDoctor()
    { 
        Debug.Log("PlagueDoctor selected");
        buildManager.SelectTowerToBuild(plagueDoctor);
    }

    public void SelectHandSanitizer()
    {
        Debug.Log("Hand Sanitizer selected");
        buildManager.SelectTowerToBuild(handSanitizer);
    }

}
