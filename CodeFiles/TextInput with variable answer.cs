using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    //Create fields for attaching an input field and a text object in Unity
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;

    //Create a public float so that the answer can be defined within Unity
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
