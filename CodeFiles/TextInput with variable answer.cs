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
    public void ValidateInput()
    {
        string input = inputField.text;

        try
        {
            float result = float.Parse(input);
            
            if (result == ans)
            {
                resultText.text = "Correct";
                bruh.SetActive(true);
            }

            else
            {
                resultText.text = "Incorrect";
            }
        }
        catch
        {
            resultText.text = "Enter a float";
        }

        

    }

}
