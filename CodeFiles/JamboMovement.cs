/*
ICS4U
Kaden Pang,Daw Da, Chingis Toktamyssov
IN UNITY, this program always runs. 
Controls Jambo's movements in Unity and other useful things tied with her.

History:
Upload date: May 1, 2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPlayerMovement : MonoBehaviour
{
    //create variables for movement speed, 
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    private Animator animator;

    public LayerMask solidObjectsLayer;

    public LayerMask interactableLayer;
    private bool check = false;

    //called when the program is ran
    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    Vector2 movement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player contacts with a game object with the tag door, it will stop movement briefly.
        if (collision.CompareTag("door"))
        {
        
            //Time.timeScale = 0;
            Debug.Log("bruh");
            StartCoroutine(stopmovement());
        }
    }
    //When this Enumerator is called, the code inside will be ran
    IEnumerator stopmovement()
    {
        //disable movement for a second while the animation of a new scene is being played
        check = true;
        moveSpeed = 0f;
        yield return new WaitForSeconds(1);
        moveSpeed = 15f;
        check = false; 
    }

    //function that is called once every frame 
    private void Update()
    {
        //get the current scene name 
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Main Menu")
        {
            // if the current scene is the main menu, disable movement 
            moveSpeed = 0f;
        }
        else
        // else if the current scene is anything else, check if we are contacting a door, if not enable movement 
        {
            if (check)
            {
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = 15f;
            }
            
        }
        

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //if the character is moving, do not allow 8D movement. This is done by disabling movement in the other direction, when one is active.
        if(movement.x == 0 && movement.y == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
   
        //Debug.Log("This is input.x" + movement.x);
        //Debug.Log("This is input.y" + movement.y);

        if(movement.x != 0 || movement.y != 0)
        {
            // play the moving animation in unity when walking
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
        }

        if (movement.x != 0)
        {
            movement.y = 0;
            animator.SetFloat("moveY", movement.y);
        }

        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
       
    }
    // this section is just used to debug the code, enable to check if doors are labelled correctly. 
    /*void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        //Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        //Debug.Log(collider);
        if (collider == null)
        {
            Debug.Log("Dawson is here");
        }
    }*/

    


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
