using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CombatAction")]
public class CombatAction_SO : ScriptableObject
{
    public string actionName;
    public string description;
    public string ap_cost;
    public string base_damage;

}
