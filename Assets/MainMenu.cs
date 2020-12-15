using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level1";
    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
        RoundSystem.roundOngoing = false;
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
