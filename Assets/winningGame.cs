using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winningGame : MonoBehaviour
{
    public string pageToLoad = "Main Menu";

    public void Menu()
    {
        SceneManager.LoadScene(pageToLoad);
        Debug.Log("Got to Menu.");
    }

}
