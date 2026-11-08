using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    public GameObject spawnpoint1;
    public GameObject spawnpoint2;
    public SpriteRenderer SR1;
    public SpriteRenderer SR2;
    public static Vector3 spawnPosition;
    public static Vector3 tutorialSpawnPosition;

    void Awake()
    {
        SR1.enabled = false;
        SR2.enabled = false;
        //Start the ghost outside of the level
        spawnPosition = spawnpoint2.transform.position;
        tutorialSpawnPosition = spawnpoint1.transform.position;
    }

    private void Update()
    {
        if (PlayerScript.hit == false)
        {
            spawnPosition = spawnpoint1.transform.position;
        }
        else if (PlayerScript.hit)
        {
            spawnPosition = spawnpoint2.transform.position;
        }
    }
}