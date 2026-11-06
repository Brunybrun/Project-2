using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public static Vector3 spawnPointPosition;
    public SpriteRenderer SR;
    public GameObject playerChar;

    void Awake()
    {
        spawnPointPosition = transform.position;
        Vector3 playerSpawn = spawnPointPosition;
        Instantiate(playerChar, playerSpawn, Quaternion.identity);
        SR.enabled = false;
    }
}
