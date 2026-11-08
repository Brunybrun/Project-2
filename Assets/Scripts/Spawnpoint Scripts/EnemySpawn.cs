using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject spawnpoint;
    public SpriteRenderer SR;
    public static Vector3 EnemySpawnPosition;

    void Awake()
    {
        SR.enabled = false;
        EnemySpawnPosition = spawnpoint.transform.position;
    }

    private void Update()
    {
        /*if (PlayerScript.hit)
        {
            EnemySpawnPosition = spawnpoint.transform.position;
        }*/
    }
}
