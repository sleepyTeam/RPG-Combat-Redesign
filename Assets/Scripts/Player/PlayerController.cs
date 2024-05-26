using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 movement;
    public PlayerStats stats;


    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
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

