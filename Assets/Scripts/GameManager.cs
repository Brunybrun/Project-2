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
        tutorial = false;
    }

    public void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial2") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial3"))
        {
            tutorial = true;
        }
    }
}
