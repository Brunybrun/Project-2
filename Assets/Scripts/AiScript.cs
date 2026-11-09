using Unity.VisualScripting;
using UnityEngine;
using static PlayerScript;

public class AiScript : MonoBehaviour
{
    public PlayerScript Target;
    public EnemyState State = EnemyState.Looking;
    public Animator Anim;
    public Rigidbody2D ERB; //Enemy Rigidbody
    public Rigidbody2D TRRB; //Target radius Rigidbody
    public GameObject Enemy;
    public GameObject TargetRadius;
    [SerializeField] float Scale;
    private float Speed = 3.5f;

    public GameObject spawnpoint;
    public SpriteRenderer SPSR;
    //private Vector3 EnemySpawnPosition;

    void Start()
    {
        if (Target == null) Target = PlayerScript.Player;
        SPSR.enabled = false;
        //Moves the position of the radius to the enemy so that I wouldn't have to move both the enemy and the radius around
        TargetRadius.transform.position = Enemy.transform.position;
        //Changes the size of the radius, meaning the enemy can chase the player from a further distance
        TargetRadius.transform.localScale = new Vector3(Scale, Scale, Scale);
    }

    void Update()
    {
        ChasePlayer();
    }

    public enum EnemyState
    {
        None = 0,
        Angry = 1,
        Looking = 2,
        Sleeping = 3
    }

    public void SetState(EnemyState s)
    {
        if (State == s) return;
        State = s;
        if (State == EnemyState.Angry)
        {
            Anim.Play("Angry");
        }
        else if (State == EnemyState.Looking)
        {
            Anim.Play("Looking");
        }
        else if (State == EnemyState.Sleeping)
        {
            Anim.Play("Sleeping");
        }
    }

    private void ChasePlayer()
    {
        EnemyState es = EnemyState.Looking;
        //Does a check to see if the player is within the radius of the enemy
        if (TargetRadiusScript.move)
        {
            //While the player isn't hit, chase the player. If the player is hit, stop chasing and move back to enemy spawnpoint
            if (PlayerScript.hit == false)
            {
                if (Target == null) return;
                Vector3 offset = Target.transform.position - transform.position;
                ERB.linearVelocity = offset.normalized * Speed;
                es = EnemyState.Angry;
            }
            else if (PlayerScript.hit)
            {
                ERB.linearVelocity = Vector2.zero;
                TRRB.linearVelocity = Vector2.zero;
                //Keeps both the enemy and the radius to stay put in its spawn location
                Enemy.transform.position = spawnpoint.transform.position;
            }
        }
        else if (TargetRadiusScript.move == false)
        {
            ERB.linearVelocity = Vector2.zero;
            if (PlayerScript.hit == false)
            {
                es = EnemyState.Looking;
            }
            else
            {
                es = EnemyState.Sleeping;
            }
        }
        SetState(es);
        TargetRadius.transform.position = Enemy.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Moves the enemy back to its spawnpoint
            Enemy.transform.position = spawnpoint.transform.position;
        }
    }
}
