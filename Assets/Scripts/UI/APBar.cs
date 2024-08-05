using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APBar : MonoBehaviour
{
    [SerializeField] float apRate;
    [SerializeField] int apMax;
    public PlayerStats stats;
    [SerializeField] PlayerController pC;
    float Current_AP;
    public List<Image> exertionSegments;
    public List<Image> apSegments;
    private void Start()
    {
        apRate = pC.apRate;
        apMax = stats.ap_max;
    }
    private void Update()
    {
        Current_AP = pC.CurrentAP;
        FillBar(Current_AP);
    }
    public void Exert(int ap_Cost)
    {

    }
    public void FillBar(float currentAP)
    {
        for(int i = 0; i < apSegments.Count; i++)
        {
            float maxfill = (i + 1) * 15.0f;
            float minfill = (i * 15.0f)/100;
            float fillAmount = (currentAP/maxfill);
            if(fillAmount > minfill)
            {
                apSegments[i].fillAmount = fillAmount;
            }
        }
    }
}
