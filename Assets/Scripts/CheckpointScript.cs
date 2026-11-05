using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject checkpoint;
    public static Vector3 checkpointPosition;
    public SpriteRenderer SR;

    void Awake()
    {
        checkpointPosition = transform.position;
        SR.enabled = false;
    }
}
