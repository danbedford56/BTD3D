using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_bar : MonoBehaviour
{
    [SerializeField]
    private Slider health_slider;

    public void set_health(int health)
    {
        health_slider.value = health;
    }
}
