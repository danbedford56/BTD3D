using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    // Update is called once per frame
    void Update()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        livesText.text = PlayerStatus.lives.ToString();
    }
}
