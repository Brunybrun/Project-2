using Unity.VisualScripting;
using UnityEngine;

public class AiScript : MonoBehaviour
{
    public PlayerScript Target;
    public Rigidbody2D ERB;
    public Rigidbody2D TRRB;
    public GameObject Enemy;
    public GameObject TargetRadius;
    [SerializeField] float Scale;
    private float Speed = 3;
    private bool move = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Target == null) Target = PlayerScript.Player;
        Enemy.transform.position = EnemySpawn.EnemySpawnPosition;
        TargetRadius.transform.localScale = new Vector3(Scale, Scale, Scale);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.hit == false && TargetRadiusScript.move)
        {
            if (Target == null) return;
            Vector3 offset = Target.transform.position - transform.position;
            ERB.linearVelocity = offset.normalized * Speed;
            TRRB.linearVelocity = offset.normalized * Speed;
        }
        else if (PlayerScript.hit)
        {
            ERB.linearVelocity = Vector2.zero;
            TRRB.linearVelocity = Vector2.zero;
            Enemy.transform.position = EnemySpawn.EnemySpawnPosition;
            TargetRadius.transform.position = EnemySpawn.EnemySpawnPosition;
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
