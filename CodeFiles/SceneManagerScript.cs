//imports unity packages
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;

    private void Awake()
    {
        //if an object is attached to the room manager, don't destroy it when going to another room
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextRoom()
    {
        //start going to the next room
        StartCoroutine(LoadLevel());
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
    //start going to a specified room
        //SceneManager.LoadSceneAsync(sceneName);
        StartCoroutine(LoadLevelspec(sceneName));
    }

    IEnumerator LoadLevelspec(string room)
    {
        //start the animation to change rooms
        transitionAnim.SetTrigger("End");
        //wait for one second
        yield return new WaitForSeconds(1);
        //load new scene
        SceneManager.LoadSceneAsync(room);
        transitionAnim.SetTrigger("Start");
    }

    IEnumerator LoadLevel()
    {
        //play animation to go to the room
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }
}
