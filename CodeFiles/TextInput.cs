/*
ICS4U
Kaden Pang
Older version of getting text input and validating it (only one valid answer).
TextInput-Health.cs is the file used in the final game
References
[1] Used for learning how to access input fields and text boxes and the proper syntax for if statements in c#


*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    //Creating fields for attaching an inputField and a text for displaying text in Unity [1]
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;

    public void ValidateInput()
    {
        //Store the user's input from the inputfield [1]
        string input = inputField.text;

        //If the input is 0.553 as a string, display correct, otherwise display incorrect [1]
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
/*
Bibliography
[1] M. O’Didily, “How to get user input and validate it using Unity,” YouTube, https://www.youtube.com/watch?v=EogkNlAkMI8 (accessed May 17, 2024). 
*/