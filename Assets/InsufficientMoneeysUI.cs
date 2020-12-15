using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsufficientMoneeysUI : MonoBehaviour
{
    public GameObject ui;

    public void Show()
    {
        ui.SetActive(true);
    }

    public void Hide ()
    {
        ui.SetActive(false);
    }
}
