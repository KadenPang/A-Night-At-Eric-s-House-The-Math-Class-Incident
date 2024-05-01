using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // spawn the sun button at the first available inventory slot ! 

            int count = 0;
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false && count == 0)
                { // check whether the slot is EMPTY
                    this.gameObject.SetActive(false);
                    count++;
                    inventory.isFull[i] = true; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Debug.Log("bruh");// spawn the button so that the player can interact with it
                    

                    //Destroy(gameObject);
                    break;
                }
            }
        }

    }
}
