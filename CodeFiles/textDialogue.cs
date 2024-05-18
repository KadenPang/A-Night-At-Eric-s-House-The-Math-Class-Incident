/*
ICS4U
Kaden Pang
This program is meant for dialogue coming from NPCs. Code was taken from online and used for learning and testing purposes. 
The modified version that is specific to A Night at Eric's house is in the DawsonDialogue.cs file

History:
Upload date: March 13, 2024
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDialogue : MonoBehaviour //[1]
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
    //Refers to the amount of different text prompts there are (how many times the continue button can change the text)
    private int index;

    // Update is called once per frame
    void Update()
    {
        //If the 'e' key is pressed and playerIsClose is true, execute this code
        if (Input.GetKeyUp(KeyCode.E) && playerIsClose) 
        {

            //If the dialogue is already active and the user presses 'e', run zeroText() which turns off the dialogue panel
            if (dialoguePanel.activeInHierarchy) 
            {
                zeroText();
            }
            

            //Turn the dialogue panel on and start typing out the message
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        //If the text displaying is everything that is to be displayed
        if (dialogueText.text == dialogue[index]) 
        {
            //Make the continue button clickable
            contButton.SetActive(true);
        }
    }

    //Function that erases the text and deactivates the dialogue panel
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    //Use IEnumerator to be used with Coroutine, which would allow for the function Typing() to be stopped while it is still executing
    IEnumerator Typing()
    {
        //For every character that is in the text to be displayed
        foreach(char letter in dialogue[index].ToCharArray())
        {
            //Add the next letter to the dialogue text 
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    /*Used to move on to the next line in the index
    Meant to be attached to the continue button in Unity*/
    public void NextLine()
    {
        //Disable the continue button so that the player has to wait until all of the code has been printed out before going to the next set of text
        contButton.SetActive(false) ;

        //If there is more text to be displayed after pressing the continue, increase the index, erase the text and start typing out the next element
        if(index < dialogue.Length -1) 
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
    }

    /*When the player sprite collides with the object that this file is attached to, playerIsClose = true, otherwise keep the dialogue panel blank*/
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

/*
Bibliography
[1] diving_squid, “Unity 2D NPC Dialogue System tutorial,” YouTube, https://www.youtube.com/watch?v=1nFNOyCalzo (accessed May 17, 2024). 
*/

