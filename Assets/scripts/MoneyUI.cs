using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneesText;
    // Update is called once per frame
    void Update()
    {
        moneesText = GetComponent<TextMeshProUGUI> ();
        moneesText.text = "£" + PlayerStatus.monees.ToString();
    }
}
