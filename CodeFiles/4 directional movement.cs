using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    // to make only 4 directional movement, deny movement in the y axis when there's movement in the x axis
        if (movement.x != 0) movement.y = 0;
    }

    // update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
