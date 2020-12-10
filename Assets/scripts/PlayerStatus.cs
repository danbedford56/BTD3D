using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static int monees;
    public int startingMonees = 400;
    public static float lives;
    public float startingLives = 200f;
    public GameObject GameOverUI;

    void Start()
    {
        monees = startingMonees;
        lives = startingLives;
    }

    private void Update()
    {
        if (lives <= 0)
        {
            lives = 0;
            Die();
        }
    }

    void Die()
    {
        Debug.Log("You lost");
        GameOverUI.SetActive(true);
    }
}
