using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 towerOffset; 

    private GameObject tower;
    private Color startColor;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("Cannot place a tower here. TODO: Display on screen");
            return; 
        }
        GameObject towerToBuild = BuildManager.instance.GetTowerToBuid();
        tower = (GameObject)Instantiate(towerToBuild, transform.position + towerOffset, transform.rotation);

    }


}
