using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Time.timeScale = 0;
            if (goNextLevel)
            {
                SceneController.instance.NextRoom();
            }
            else
            {
                SceneController.instance.LoadScene(levelName);
            }
            
        }
    }
}
