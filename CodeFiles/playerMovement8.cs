/*
ICS4U
Kaden Pang
This was the original 8 directional 2D top down movement code. Final code used in the project is in playerMovement4.cs
Code was taken from online to learn how Unity has set up their movement

History:
Upload date: February 8, 2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// old version of player movement, allows for 8 directional movement

public class NewPlayerMovement : MonoBehaviour
{
    // define a movement speed variable
    public float moveSpeed = 5f;
    //Access the rigidbody of the game object this file is a component of to be able to move its position
    public Rigidbody2D rb;

    //Create a Vector2 variable to store x and y position
    Vector2 movement;

    void Update()
    
    {
    // get user input for either horizontal movement keys (left right) or vertical movement keys (up down)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //Move the rigidbody to a new position which is the original position + new movement * movement speed * Time.fixedDeltaTime
        //Time.fixedDeltaTime will make sure that it is always at a constant speed, no matter the frame rate
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

/*
Bibliography

[1] Brackeys, “Top down movement in unity!,” YouTube, https://www.youtube.com/watch?v=whzomFgjT50 (accessed May 17, 2024). 

*/