using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] bool vertical;
    public Rigidbody2D RB;
    private int Speed = 4;
    private bool up = true;
    private bool right = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

    private void MoveVertically()
    {
        Vector2 vel = Vector2.zero;
        if (up)
        {
            vel.y += Speed;
            if (transform.position.y > 4)
            {
                up = false;
            }
        }
        else if (up == false)
        {
            vel.y -= Speed;
            if (transform.position.y < -4)
            {
                up = true;
            }
        }
        RB.linearVelocity = vel;
    }

    private void MoveHorizontally()
    {
        Vector2 vel = Vector2.zero;
        if (right)
        {
            vel.x += Speed + 2;
            if (transform.position.x > 10)
            {
                right = false;
            }
        }
        else if (right == false)
        {
            vel.x -= Speed + 2;
            if (transform.position.x < 7)
            {
                right = true;
            }
        }
        RB.linearVelocity = vel;
    }
}
