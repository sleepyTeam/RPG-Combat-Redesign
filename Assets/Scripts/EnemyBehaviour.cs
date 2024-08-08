using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Enemy_SO EnemyStats;
    public int CurrentHealth;

    private void Start()
    {
        CurrentHealth = EnemyStats.Health;
    }
}

