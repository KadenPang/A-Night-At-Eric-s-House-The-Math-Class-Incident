using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;

    public void ValidateInput()
    {
        string input = inputField.text;

        if (input == "0.553")
        {
            resultText.text = "Correct";

        }

        else
        {
            resultText.text = "Incorrect";
        }

    }

}
