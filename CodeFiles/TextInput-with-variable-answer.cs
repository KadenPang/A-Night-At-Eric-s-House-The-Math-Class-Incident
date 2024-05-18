/*
ICS4U
Kaden Pang, Daw Da
This is a more modular version of the TextInput.cs file, where the valid input is defined within the Unity game engine.

History:
Upload date: March 29, 2024

References:
[1] Used for learning how to access input fields and text boxes and the proper syntax for if statements in c#
[2] Used for learning how to convert string to float in C#
[3] Used for learning Try statements in C#
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    //Create fields for attaching an input field and a text object in Unity [1]
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;

    //Create a public float so that the answer can be defined within Unity
    public float ans;

    //Create a public game object that will be disabled if the valid input is entered
    public GameObject door;


    /*Asks for a string input and checks if it is the correct float*/
    public void ValidateInput()
    {
        //Store the user's input as a string in a variable
        string input = inputField.text;

        try //[3]
        {
            //Try to convert the input into a float and store it as the result variable [2]
            float result = float.Parse(input); 
            
            //If the result is equal to the global variable ans which is defined in Unity
            if (result == ans)
            {
                //Display "Correct" to the user and deactivate the door block
                resultText.text = "Correct";
                door.SetActive(false);
            }

            //As long as the input is a float but not the correct answer, display "Incorrect"
            else
            {
                resultText.text = "Incorrect";
            }
        }

        //While the user does not enter a float, display "Enter a float"
        catch
        {
            resultText.text = "Enter a float";
        }

        

    }

}

/*
Bibliography
[1] M. O’Didily, “How to get user input and validate it using Unity,” YouTube, https://www.youtube.com/watch?v=EogkNlAkMI8 (accessed May 17, 2024). 
[2] B. Wagner, “How to convert a string to a number - C#,” How to convert a string to a number - C# | Microsoft Learn, https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number (accessed May 17, 2024). 
[3] [1] “C# exceptions - try..catch,” C# Exceptions (Try..Catch), https://www.w3schools.com/cs/cs_exceptions.php (accessed May 17, 2024). 
*/