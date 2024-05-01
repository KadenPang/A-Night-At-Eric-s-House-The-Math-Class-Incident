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
        if (lastScene.name != "Main Menu")
        {
            Scene currentScene = SceneManager.GetActiveScene();
            currentName = currentScene.name;
        }
        
    }
}
