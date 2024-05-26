using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerStats stats;
    public float fillPercent;
    public Image hpBar;

    void Update()
    {
        fillPercent = stats.healthPercent;
        hpBar.fillAmount = fillPercent;
    }
}
