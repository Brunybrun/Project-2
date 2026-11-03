using UnityEngine;

public class AiScript : MonoBehaviour
{
    public PlayerScript Target;
    public float Speed = 3;
    public Rigidbody2D RB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Target == null) Target =  PlayerScript.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null) return;
        Vector3 offset = Target.transform.position - transform.position;
        RB.linearVelocity = offset.normalized * Speed;
    }
}
