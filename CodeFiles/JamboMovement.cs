using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    private Animator animator;

    public LayerMask solidObjectsLayer;

    public LayerMask interactableLayer;
    private bool heheheha = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    Vector2 movement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("door"))
        {
        
            //Time.timeScale = 0;
            Debug.Log("bruh");
            StartCoroutine(stopmovement());
        }
    }
    IEnumerator stopmovement()
    {
        heheheha = true;
        moveSpeed = 0f;
        yield return new WaitForSeconds(1);
        moveSpeed = 15f;
        heheheha = false; 
    }

    private void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Main Menu")
        {
            moveSpeed = 0f;
        }
        else
        {
            if (heheheha)
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

    void Interact()
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
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
