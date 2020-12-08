
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // make new public void to get different towers

    public void GetTurret()
    {
        Debug.Log("Turret selected");
        buildManager.SetTowerToBuild(buildManager.defaultTower);
    }

}
