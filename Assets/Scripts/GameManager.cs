using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager god;
    public static bool startAtSpawn;
    public static bool tutorial;
    void Awake()
    {
        god = this;
        startAtSpawn = true;
        tutorial = true;
    }

    public void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
        {
            tutorial = false;
        }
    }
}
