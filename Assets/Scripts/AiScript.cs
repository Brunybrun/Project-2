using Unity.VisualScripting;
using UnityEngine;

public class AiScript : MonoBehaviour
{
    public PlayerScript Target;
    public Rigidbody2D RB;
    public GameObject Enemy;
    public float Speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Target == null) Target = PlayerScript.Player;
        Enemy.transform.position = EnemySpawn.EnemySpawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.hit == false)
        {
            if (Target == null) return;
            Vector3 offset = Target.transform.position - transform.position;
            RB.linearVelocity = offset.normalized * Speed;
        }
        else if (PlayerScript.hit)
        {
            RB.linearVelocity = Vector2.zero;
            Enemy.transform.position = EnemySpawn.EnemySpawnPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Enemy.transform.position = EnemySpawn.EnemySpawnPosition;
        }
    }
}
