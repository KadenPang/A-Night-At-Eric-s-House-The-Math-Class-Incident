// https://www.youtube.com/watch?v=EogkNlAkMI8
//Older version of getting text input with only one valid answer

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    //Creating fields for attaching an inputField and a text for displaying text in Unity
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;

    public void ValidateInput()
    {
        //Store the user's input from the inputfield
        string input = inputField.text;

        //If the input is 0.553 as a string, display correct, otherwise display incorrect
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
