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
    public float Current_AP;
    public Image ExertImage;
    public Image APImage;
    public float maxFill;
    public float ExertRecoveryRate;
    public float TotalExertion;
    private void Start()
    {
        apRate = pC.apRate;
        maxFill = pC.APMax;
        ExertRecoveryRate = apRate / 2;
    }
    private void Update()
    {
        if (Current_AP < maxFill)
        {
            Current_AP = pC.CurrentAP;
        }
        else Current_AP = maxFill;
        
        FillBar(Current_AP);
        if (Input.GetKeyDown(KeyCode.E)){
            Exert(15);
        }

        if(TotalExertion > 0)
        {
            //Recovery(ExertRecoveryRate);
        }
    }
    public void Exert(int ap_Cost)
    {
        TotalExertion += ap_Cost;
        float fillPercent = ap_Cost/apMax;
        maxFill -= ap_Cost;
        ExertImage.fillAmount += fillPercent;
    }
    public void FillBar(float currentAP)
    {
        float maxFillPercent = maxFill / 100; 
        float fillPercent = currentAP / apMax;
        if (fillPercent <= maxFillPercent)
            APImage.fillAmount = fillPercent;
        else
            APImage.fillAmount = maxFillPercent; 
    }
    //public void Recovery(float recoveryRate)
    //{
    //    TotalExertion -= recoveryRate;
    //    maxFill += recoveryRate;
    //    ExertImage.fillAmount -= TotalExertion / apMax;
    //}
}
