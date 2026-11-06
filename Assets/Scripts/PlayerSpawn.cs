using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public static Vector3 spawnPointPosition;
    public GameObject playerChar;
    private SpriteRenderer SR;

    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = false;
        spawnPointPosition = transform.position;
        Vector3 playerSpawn = spawnPointPosition;
        Instantiate(playerChar, playerSpawn, Quaternion.identity);
    }
}
