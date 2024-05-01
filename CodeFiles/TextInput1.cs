using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;


    public float ans;

    public GameObject bruh;
    //Health need;

    public void ValidateInput()
    {
        string input = inputField.text;
        float number;

        bool success = float.TryParse(input, out number);
        
        if (success)
        {
            float result = float.Parse(input);
            
            if (result == ans)
            {
                resultText.text = "Correct";
                bruh.SetActive(false);
            }

            else
            {
                resultText.text = "Incorrect";
                GameManager.gameManager._playerHealth.DmgUnit(1);
                Debug.Log(GameManager.gameManager._playerHealth.Health);
               
            }
               
        }
        else
        {
            resultText.text = "Enter a float";
        }

    }


}

