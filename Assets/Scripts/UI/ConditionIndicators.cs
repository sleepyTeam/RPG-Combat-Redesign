using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class ConditionIndicators : MonoBehaviour
{
    public PlayerStats stats;
    public List<GameObject> indicators;
    public List<Image> icons;
    public List<TextMeshProUGUI> textboxes;
    public Color buff_color;
    public Color debuff_color;
    public Color neutral_color;

    
    // Start is called before the first frame update
    void Start()
    {
        foreach(var indicator in indicators)
        {
            icons.Add(indicator.GetComponentInChildren<Image>());
            textboxes.Add(indicator.GetComponentInChildren<TextMeshProUGUI>());
        }

    }
    

    void setMoveSpeed()
    {
        Image icon = icons[0];
        float movespeedMod = stats.msModifier;
        TextMeshProUGUI text = textboxes[0];

        if(movespeedMod> 0)
        {
            text.text = "+ " + (movespeedMod*100).ToString() + "%";
            icon.color = buff_color;
        }
        else if(movespeedMod == 0)
        {
            text.text = "+0%";
            icon.color = neutral_color;
        }
        else
        {
            text.text = (movespeedMod*100).ToString() + "%";
            icon.color = debuff_color;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        setMoveSpeed();
    }
}
