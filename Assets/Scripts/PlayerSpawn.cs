using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public static Vector3 spawnPointPosition;
    private SpriteRenderer SR;

    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = false;
        spawnPointPosition = transform.position;
    }
}
