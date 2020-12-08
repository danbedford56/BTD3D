using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject defaultTower;
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

    void Start()
    {
        towerToBuild = defaultTower;
    }

    public GameObject GetTowerToBuid()
    {
        return towerToBuild;
    }
}
