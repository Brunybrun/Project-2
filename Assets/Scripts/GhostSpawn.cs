using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    public GameObject spawnpoint1;
    public GameObject spawnpoint2;
    public SpriteRenderer SR1;
    public SpriteRenderer SR2;
    public static Vector3 spawnPosition;

    void Awake()
    {
        SR1.enabled = false;
        SR2.enabled = false;
        spawnPosition = spawnpoint2.transform.position;
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