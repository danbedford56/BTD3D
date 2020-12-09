using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    [Header("isOptional")]
    public GameObject tower;

    BuildManager buildManager;
    
    private Color startColor;
    private Renderer rend;

    //On start, make a new instance of build manager.
    //Sets the starting node color to the color set in Unity. 
    void Start()  
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    //When the user hovers over a node, it there isnt a tower there, it will display a hover color. 
    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;

        if (!buildManager.HasMonees)
        {
            rend.material.color = Color.red;
        }
        else
        {
            rend.material.color = hoverColor;
        }

    }


    //When the user stops hovering over a node, the color of the node is set back to the default color. 
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }


    //When the user clicks on a node, if there is not a tower there already, and there is a tower selected to place, it places a tower on the node. 
    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;

        if (tower != null)
        {
            Debug.Log("Cannot place a tower here. TODO: Display on screen");
            return; 
        }

        buildManager.BuildTowerOn(this);

    }


    //This sets the build position to the node position plus the tower offset which is the distance above the node. 
    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }


}
