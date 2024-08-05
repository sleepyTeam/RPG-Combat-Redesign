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
    private void Start()
    {
        APMax = stats.ap_max;
        apRate = stats.ap_base_rate;
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        if((CurrentAP += apRate / 100) >= 100)
        {
            CurrentAP = 100;
        };
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
    void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

