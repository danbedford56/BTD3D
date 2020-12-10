using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundUI : MonoBehaviour
{
    public TextMeshProUGUI roundText;
    // Update is called once per frame
    void Update()
    {
        roundText = GetComponent<TextMeshProUGUI>();
        roundText.text = (RoundSystem.currentRound + 1).ToString();
    }
}
