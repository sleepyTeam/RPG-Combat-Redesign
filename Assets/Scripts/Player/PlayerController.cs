using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2;
    public float apRate;

    public Rigidbody2D rb;
    private Vector2 movement;
    public PlayerStats stats;
    public float CurrentAP= 0;
    public float APMax;
    public bool EnemySelectionMode;
    public EnemyBehaviour SelectedEnemy;
    public int selectionIndex;
    public GameObject selectionIndicator;
    
    private void Awake()
    {
        APMax = stats.ap_max;
        apRate = stats.ap_base_rate;
    }
    private void Update()
    {
        selectionIndicator.SetActive(EnemySelectionMode);
        if(Input.GetKeyDown(KeyCode.Return))
        {
            EnemySelectionMode = !EnemySelectionMode;
        }
        if (EnemySelectionMode == false)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");

                if ((CurrentAP += apRate / 100) >= 100)
                {
                    CurrentAP = 100;
                };
            }
        else if (EnemySelectionMode == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                selectionIndex -= 1;
                SelectedEnemy = EnemySelect(selectionIndex);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                selectionIndex += 1;
                SelectedEnemy = EnemySelect(selectionIndex);
            }
            else
            {
                SelectedEnemy = EnemySelect(selectionIndex);
            }
        }
        
    }
    private void FixedUpdate() //fixed update is called at regular intervals 
    {
        Move();
    }

    void Dodge()
    {
        // initiate animation
        // make immune to damage
        // apply action point cost
        Debug.Log("Dodge");
    }
    public GameObject[] GetEnemies()
    {
        GameObject[] EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        return EnemyArray;
    }
    public EnemyBehaviour EnemySelect(int index)
    {
        GameObject[] enemies = GetEnemies();
        GameObject enemy = enemies[index];
        return enemy.GetComponent<EnemyBehaviour>();
    }
    void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

