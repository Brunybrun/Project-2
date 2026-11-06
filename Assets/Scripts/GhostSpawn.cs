using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    public GameObject spawn;
    public static Vector3 spawnPosition;
    private SpriteRenderer SR;

    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = false;
        spawnPosition = transform.position;
    }
}