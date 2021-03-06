﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static int monees;
    public int startingMonees = 400;
    public static float lives;
    public float startingLives = 200f;
    public static float Rounds;
  
    public GameObject GameOverUI;
    public GameObject WinningUI;

    void Start()
    {
        monees = startingMonees;
        lives = startingLives;
        Rounds = 0;
    }

    private void Update()
    {
        

        if (Input.GetKeyDown("e"))
        {
            Die();
            RoundSystem.roundOngoing = false;
        }

        if (lives <= 0)
        {
            lives = 0;
            Die();
            RoundSystem.roundOngoing = false;
        }

        if (RoundSystem.currentRound == 6 && RoundSystem.enemiesAlive == 0)
        {
            WinningUI.SetActive(true);
        }
    }

    void Die()
    {
        Debug.Log("You lost");
        GameOverUI.SetActive(true);
        RoundSystem.currentRound = 0;
    }
}

