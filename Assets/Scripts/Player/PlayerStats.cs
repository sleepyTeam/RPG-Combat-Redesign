using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int max_health;
    public int current_health;
    public float healthPercent;
    public int ap_max;
    public float ap_base_rate;
    public float baseMS;
    private float _ms_modifier;
    public float msModifier
    {
        get { return _ms_modifier; } 
        set {if(_ms_modifier == value) return;
            _ms_modifier = value;
            if (msChange != null)
                msChange(_ms_modifier);
            }
    }
    public float damage_modifier;
    public float ap_rate_modifier;

    public PlayerController pC;
    public delegate void OnVarChangeDelegate(float value);
    public event OnVarChangeDelegate msChange;


    private void Start()
    {
        baseMS = pC.moveSpeed;
        msChange += msChangeHandler;
    }

    private void msChangeHandler(float value)
    {
        pC.moveSpeed = baseMS * (1 + value);
    }
    private void Update()
    {
        healthPercent = (float)current_health / max_health;
        if(Input.GetKeyDown(KeyCode.Space)){
            msModifier += .25f;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            msModifier -= .25f;
        }
    }
}

