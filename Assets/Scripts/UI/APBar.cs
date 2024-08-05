using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APBar : MonoBehaviour
{
    [SerializeField] float apRate;
    [SerializeField] float apMax;
    public PlayerStats stats;
    [SerializeField] PlayerController pC;
    float Current_AP;
    public Image ExertImage;
    public Image APImage;
    private void Start()
    {
        apRate = pC.apRate;
        apMax = pC.APMax;
    }
    private void Update()
    {
        
        Current_AP = pC.CurrentAP;
        FillBar(Current_AP);
        if (Input.GetKeyDown(KeyCode.E)){
            Exert(15);
        }
    }
    public void Exert(int ap_Cost)
    {
        float baseAP = apMax;
        float fillPercent = ap_Cost/baseAP;
        apMax -= ap_Cost;
        pC.APMax -= ap_Cost;
        ExertImage.fillAmount += fillPercent;
    }
    public void FillBar(float currentAP)
    {
        float maxfill = apMax;
        float fillPercent = currentAP / maxfill;
        APImage.fillAmount = fillPercent;
        
    }
}
