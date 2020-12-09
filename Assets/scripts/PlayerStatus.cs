using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static int monees;
    public int startingMonees = 400;
    public static float lives;
    public float startingLives = 200f;

    void Start()
    {
        monees = startingMonees;
        lives = startingLives;
    }
}
