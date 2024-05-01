using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTracker : MonoBehaviour
{
    public string currentName;
    void Update()
    {
        Scene lastScene = SceneManager.GetActiveScene();
        //If the current scene is not the main menu
        if (lastScene.name != "Main Menu")
        {
            // Gets the current scene the player is in as a game object
            Scene currentScene = SceneManager.GetActiveScene();
            // Turns the game object into the string of the currentName variable to be accessed
            currentName = currentScene.name;
        }
        
    }
}
