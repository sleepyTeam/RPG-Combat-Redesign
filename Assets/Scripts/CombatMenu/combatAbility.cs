using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class combatAbility : MonoBehaviour
{
    public CombatAction_SO actionData;
    public TextMeshProUGUI Name;
    
    // Start is called before the first frame update
    void Start()
    {
        Name.text = actionData.name + actionData.ap_cost;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
