using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static int monees;
    public int startingMonees = 400;

    void Start()
    {
        monees = startingMonees;
    }
}
