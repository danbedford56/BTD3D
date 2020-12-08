using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject defaultTower; //make new variables for each new tower
    private GameObject towerToBuild;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("There is already a BuildManager");
            return;
        }
        instance = this;
    }

  
    public GameObject GetTowerToBuid()
    {
        return towerToBuild;
    }

    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }
}
