//LINK TO YOUTUBE TUTORIAL https://www.youtube.com/watch?v=1nFNOyCalzo 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;

    public float wordSpeed;
    public bool playerIsClose;

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

    public void NextLine()
    {
        contButton.SetActive(false) ;

        if(index < dialogue.Length -1) 
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }

        else
        {
            zeroText() ;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
