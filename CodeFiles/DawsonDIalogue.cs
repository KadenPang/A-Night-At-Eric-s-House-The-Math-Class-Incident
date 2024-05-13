/*

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DawsonDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject inputField;


    public GameObject contButton;

    public float wordSpeed;
    public bool playerIsClose;
    int health;

    // Update is called once per frame
    void Update()
    {
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

    public void NextLine()
    {
        contButton.SetActive(false);

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
