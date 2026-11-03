using UnityEngine;

public class AiScript : MonoBehaviour
{
    public Rigidbody2D RB;
    private int speed = 1;
    private bool up = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = Vector2.zero;
        if (up)
        {
            vel.y += speed;
            if (transform.position.y > 4)
            {
                up = false;
            }
        }
        else if (up == false)
        {
            vel.y -= speed;
            if (transform.position.y < -4)
            {
                up = true;
            }
        }
        RB.linearVelocity = vel;
    }
}
