using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject checkpoint;
    public static Vector3 checkpointPosition;
    private SpriteRenderer SR;

    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            checkpointPosition = transform.position;
        }
    }
}
