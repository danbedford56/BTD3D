using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nature : MonoBehaviour
{
    public int costToDestroy;
    public Vector3 positionOffset;

    public void DestroyNature()
    {
        PlayerStatus.monees -= costToDestroy;
    }
}
