using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // health

    public int max_health;
    [Range(0f,100f)] public int current_health;
    public float healthPercent;

    // ap
    public int ap_max;
    public float ap_base_rate;
    private float _ap_rate_modifier;
    public float ap_rate_modifier
    {
        get { return _ap_rate_modifier; }
        set
        {
            if (_ap_rate_modifier == value) return;
            _ap_rate_modifier = value;
            if (apChange != null)
                apChange(_ap_rate_modifier);
        }
    }
    public void apChangeHandler(float value)
    {
        pC.apRate = ap_base_rate* (1+value);
    }
  
    // Movespeed
    
    public float baseMS;
    private float _ms_modifier;
    public float msModifier
    {
        get { return _ms_modifier; }
        set
        {
            if (_ms_modifier == value) return;
            _ms_modifier = value;
            if (msChange != null)
                msChange(_ms_modifier);
        }
    }
    public void msChangeHandler(float value)
    {
        pC.moveSpeed = baseMS * (1 + value);
    }

    //Damage
    public int base_damage;
    private float modified_Damage;
    public float _damage_modifier;
    public float damage_modifier
    {
        get { return _damage_modifier; }
        set
        {
            if (_damage_modifier == value) return;
            _damage_modifier = value;
            if(damageChange != null)
                damageChange(_damage_modifier);
        }
    }
    public void damageChangeHandler(float value)
    {
        modified_Damage = base_damage* (1+value);
    }

    public PlayerController pC;
    public delegate void OnVarChangeDelegate(float value);
    public event OnVarChangeDelegate msChange;
    public event OnVarChangeDelegate apChange;
    public event OnVarChangeDelegate damageChange;
    private void Start()
    {
        baseMS = pC.moveSpeed;
        msChange += msChangeHandler;
        apChange += apChangeHandler;
        damageChange += damageChangeHandler;
    }

    private void Update()
    {
        healthPercent = (float)current_health / max_health;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            msModifier += .25f;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            msModifier -= .25f;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ap_rate_modifier += .25f;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ap_rate_modifier -= .25f;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            damage_modifier += .25f;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            damage_modifier -= .25f;
        }
    }
}

