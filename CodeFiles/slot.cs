
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Slot : MonoBehaviour
{


    private Inventory inventory;
    public int i;

    private void Start()
    {

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }

    public void DropItem()
    {

        foreach (Transform child in transform)
        {
            //child.GetComponent<Spawn>().SpawnDroppedItem();
            GameManager.gameManager._playerHealth.HealUnit(1);
            GameObject.Destroy(child.gameObject);
        }
    }

}
