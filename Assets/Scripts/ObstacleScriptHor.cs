using UnityEngine;

public class ObstacleScriptHor : MonoBehaviour
{
    public Rigidbody2D RB;
    private int Speed = 6;
    private bool right = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = Vector2.zero;
        if (right)
        {
            vel.x += Speed;
            if (transform.position.x > 10)
            {
                right = false;
            }
        }
        else if (right == false)
        {
            vel.x -= Speed;
            if (transform.position.x < 7)
            {
                right = true;
            }
        }
        RB.linearVelocity = vel;
    }
}
