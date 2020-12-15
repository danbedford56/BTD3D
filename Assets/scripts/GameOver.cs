using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    public string pageToLoad = "Main Menu";

    void OnEnable()
    {
        roundsText.text = PlayerStatus.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        RoundSystem.roundOngoing = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene(pageToLoad);
        Debug.Log("Got to Menu.");
    }
}
