using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 10f, 10f) * Time.deltaTime);
    }
}
