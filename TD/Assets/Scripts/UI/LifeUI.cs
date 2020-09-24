using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Text livesText;
    void Update()
    {
        livesText.text = "목숨: " + PlayerStat.Lives.ToString();
    }
}
