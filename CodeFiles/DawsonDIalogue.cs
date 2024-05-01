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
                inputField.SetActive(true);
            }
        }

        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        if (health <= 0)
        {
            dialoguePanel.SetActive(false);
        }
        else
        {
            dialogueText.text = "";
            index = 0;
            dialoguePanel.SetActive(false);
            inputField.SetActive(false);
            StopCoroutine(Typing());
        }
        
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
