using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpened : MonoBehaviour
{
    public bool door1 = false;
    public GameObject bruh;


    void Update()
    {
        if (door1 == true)
        {   
            bruh.SetActive(false);
        }
 
    }
}
