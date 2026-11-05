using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    public GameObject spawn;
    public static Vector3 spawnPosition;
    public SpriteRenderer SR;

    void Awake()
    {
        spawnPosition = transform.position;
        SR.enabled = false;
    }
}