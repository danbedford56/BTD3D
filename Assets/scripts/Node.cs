using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 towerOffset;
    BuildManager buildManager;
    private GameObject tower;
    private Color startColor;
    private Renderer rend;

    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        if (buildManager.GetTowerToBuid() == null)
            return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (buildManager.GetTowerToBuid() == null)
            return;

        if (tower != null)
        {
            Debug.Log("Cannot place a tower here. TODO: Display on screen");
            return; 
        }
        GameObject towerToBuild = buildManager.GetTowerToBuid();
        tower = (GameObject)Instantiate(towerToBuild, transform.position + towerOffset, transform.rotation);

    }


}
