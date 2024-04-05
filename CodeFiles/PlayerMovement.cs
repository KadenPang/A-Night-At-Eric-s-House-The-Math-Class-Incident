using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// old version of player movement, allows for 8 directional movement

public class NewPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    void Update()
    
    {
    // get user input for either horizontal movement keys (left right) or vertical movement keys (up down)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
