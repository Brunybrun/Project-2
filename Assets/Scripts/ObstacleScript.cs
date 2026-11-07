using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public Rigidbody2D RB;
    [SerializeField] int Speed;
    [SerializeField] bool vertical;
    [SerializeField] bool stationary;

    void Update()
    {
        if (stationary == false)
        {
            if (vertical)
            {
                MoveVertically();
            }
            else
            {
                MoveHorizontally();
            }
        }
    }

    private void MoveVertically()
    {
        Vector2 vel = Vector2.zero;
        vel.y += Speed;
        RB.linearVelocity = vel;
    }

    private void MoveHorizontally()
    {
        Vector2 vel = Vector2.zero;
        vel.x += Speed;
        RB.linearVelocity = vel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpikeTrigger")
        {
            Speed = Speed * -1;
        }
    }
}
