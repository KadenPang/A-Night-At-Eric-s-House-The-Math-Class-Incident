/*
ICS4U
Kaden Pang, Daw Da, Chingis Toktamyssov
Another file that was used for testing the NPC interactions.
Not used for anything in the final program
File used in the final game is DawsonDialogue.cs
File with the intial code taken from online is textDialogue.cs
Both of those files have comments and code that are used here

History:
Upload date: May 1, 2024
*/

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
        // If the space key is pressed while the player is touching the collide of the game object that this file is a component of, start the dialogue
        if (Input.GetKeyUp(KeyCode.Space) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }

            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        StopCoroutine(Typing());
    }

    IEnumerator Typing()
    {
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
