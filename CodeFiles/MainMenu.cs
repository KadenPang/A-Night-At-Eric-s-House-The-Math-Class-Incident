using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public sceneTracker a;
    public GameObject instructionPanel;
    public void PlayGame()
    {
        a = FindObjectOfType<sceneTracker>();
        //Time.timeScale = 1;
        if(a.currentName == "")
        {
            SceneManager.LoadSceneAsync(3);
        }
        else
        {
            SceneManager.LoadSceneAsync(a.currentName);
        }
    }

    public void Instructions()
    {
        instructionPanel.SetActive(true);
    }
    public void close()
    {
        instructionPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
