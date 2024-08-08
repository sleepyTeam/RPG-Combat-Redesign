using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy_SO : ScriptableObject
{
    public string EnemyName;
    public int Health;

    public int Vigor;
    public int Strength;
    public int Dexterity;
    public int Precision;
    public int Intellect;
    public int Resilience;
    public int Arcana;

}
