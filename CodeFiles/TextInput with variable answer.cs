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

    public GameObject door;
    /**
    Asks for a string input and checks if it is the correct float
    */
    public void ValidateInput()
    {
        //Store the user's input as a string in a variable
        string input = inputField.text;

        try
        {
            //Try to convert the input into a float and store it as the result variable
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

        //While the user does not have a float, display "Enter a float"
        catch
        {
            resultText.text = "Enter a float";
        }

        

    }

}
