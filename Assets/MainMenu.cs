using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public string level1 = "Level1";
    //public string level2 = "Level2";
    public void PlayLev1()
    {
        SceneManager.LoadScene("Level 1");
        RoundSystem.roundOngoing = false;
    }

    public void Playlev2()
    {
        SceneManager.LoadScene("Level 2");
        RoundSystem.roundOngoing = false;
    } 

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
