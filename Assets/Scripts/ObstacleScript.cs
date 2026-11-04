using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public GameObject Spike;
    private int spikeAmount = 5;
    private int speed = 4;
    private bool up = true;
    private float num = 0;
    private float negativeNum = -1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        while (num < spikeAmount)
        {
            Vector3 spikeSpawn = new Vector3((-7f + (num * 2f)), (4f * negativeNum), 0f);
            Instantiate(Spike, spikeSpawn, Quaternion.identity);
            num++;
        }
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
