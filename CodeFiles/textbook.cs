using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textbook : MonoBehaviour
{
    public GameObject image;
    public bool playerIsClose;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && playerIsClose)
        {
            if (image.activeInHierarchy)
            {
                image.SetActive(false);
            }
            else
            {
                image.SetActive(true);
            }
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
            playerIsClose = false;
            image.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            image.SetActive(false);
        }
    }
}
