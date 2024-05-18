/*
ICS4U
Kaden Pang,Daw Da, Chingis Toktamyssov
IN UNITY, this program runs when the user presses the space key while close to whatever this object this file is a component of. 
Displays to the user some text that which is entered as an element within Unity
Built off of the textDialogue.cs file
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DawsonDialogue : MonoBehaviour
{
    //Create public variables for attaching the appropriate game objects. Game objects will need to be created and assigned
    //Should be a UI Panel
    public GameObject dialoguePanel;
    //Should be a UI text (legacy)
    public Text dialogueText;
    //This will be the actual text that should be printed
    public string[] dialogue;


    //Should be a UI inputfield (legacy)
    public GameObject inputField;
    //Should be a UI button
    public GameObject contButton;

    //Float that represents how long the program should wait before printing out the next character
    public float wordSpeed;
    //Bool for whether or not the player sprite is nearby
    //The game object that this is attached to should already have some sort of collider component
    public bool playerIsClose;
    //int variable for storing the health of the player
    int health;

    //Refers to the amount of different text prompts there are (how many times the continue button can change the text)
    private int index;
    
    // Update is called once per frame
    void Update()
    {
        //Access the value to be assigned as the health of the player through the game manager
        health = GameManager.gameManager._playerHealth.Health;
      
        //If the user presses space and playerIsClose (meaning the player sprite is touching this game object)
        if (Input.GetKeyUp(KeyCode.Space) && playerIsClose)
        {
            //If text is already showing, turn it off using the zerotext() function
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }

            else
            {
                //Set the dialoguePanel to true so that the user can see it 
                dialoguePanel.SetActive(true);
                //Run the Typing() function using Coroutine so that it can be stopped before all the code in Typing() is executed
                StartCoroutine(Typing());
                //Turn on the inputfield so that the user can see it and can enter values in it
                inputField.SetActive(true);
            }
        }

        //If all of the text is now displayed, allow the user to press the continue button
        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        //If the player loses all their health, deactivate the dialogue panel
        if (health <= 0)
        {
            dialoguePanel.SetActive(false);
        }
        else
        {
            //Remove all the text and the fields with text in them and reset everything so that the next time this is activated, it is blank again
            dialogueText.text = "";
            index = 0;
            dialoguePanel.SetActive(false);
            inputField.SetActive(false);
            StopCoroutine(Typing());
        }
        
    }

    //Use IEnumerator to be used with Coroutine, which would allow for the function Typing() to be stopped while it is still executing
    IEnumerator Typing()
    {
        //For every character in the element that is being printed right now, wait for wordSpeed seconds until printing the next letter
        foreach (char letter in dialogue[index].ToCharArray())
        {
            if (dialoguePanel.activeInHierarchy)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
            }
            
        }
    }

    /*Used to move on to the next line in the index
    Meant to be attached to the continue button in Unity*/
    public void NextLine()
    {
        //Disable the continue button so that the player has to wait until all of the code has been printed out before going to the next set of text
        contButton.SetActive(false);

        //If there is more text to be displayed after pressing the continue, increase the index, erase the text and start typing out the next element
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
    }

    /*When the player sprite collides with the object that this file is attached to, playerIsClose = true*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }

        else
        {
            zeroText();
        }
    }

    /*When the player sprite is no longer in contact with the collider of this object, playerIsClose = false and the text is erased using the zerotext() function*/
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
