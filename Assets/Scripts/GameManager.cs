using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager god;
    public static bool startAtSpawn;
    void Awake()
    {
        god = this;
        startAtSpawn = true;
    }
}
