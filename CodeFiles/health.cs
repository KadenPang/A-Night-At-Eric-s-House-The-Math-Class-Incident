using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Healthbar : MonoBehaviour
{
    int health;
    int numOfHearts;
    
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private bool heheheha = false;
    
    void Update()
    {

        //if (numOfHearts <= 0)
        //{
        //    SceneManager.LoadSceneAsync(7);
        //}
        Debug.Log(health);
        Debug.Log(numOfHearts);
        health = GameManager.gameManager._playerHealth.Health;
        numOfHearts = GameManager.gameManager._playerHealth.MaxHealth;

        
        if (health <= 0)
        {
            if (!heheheha)
            {
                SceneManager.LoadSceneAsync(9);
                heheheha = true;
            }

        }


        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHeart;

            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;

            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void SetMaxHealth(int maxHealth)
    {
        numOfHearts = maxHealth;
    }
    public void SetHealth(int curhealth)
    {
        health = curhealth;
    }


}
