using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Player;

    public PlayerState State = PlayerState.Alive;
    public Animator Anim;
    public static bool hit;
    public Rigidbody2D RB;
    private int Speed = 4;
    public GameObject ghost;

    private void Awake()
    {
        Player = this;
    }
    void Start()
    {
        hit = false;
    }

    void Update()
    {
        if (State == PlayerState.Alive)
        {
            PlayerMovement();
        }
        else if (State == PlayerState.Dead)
        {
            DeadPlayerMovement();
        }
    }

    public enum PlayerState{
         None=0,
         Alive=1,
         Dead=2
    }

    public void PlayerMovement()
    {
        PlayerState s = PlayerState.Alive;
        Vector2 vel = Vector2.zero;
        if (Keyboard.current.wKey.isPressed)
        {
            vel.y += Speed;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            vel.y -= Speed;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            vel.x += Speed;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            vel.x -= Speed;
        }
        if (hit == true)
        {
            s = PlayerState.Dead;
        }
        SetState(s);
        RB.linearVelocity = vel;
    }

    public void DeadPlayerMovement()
    {
        PlayerState s = PlayerState.Dead;
        Vector2 vel = Vector2.zero;
        if (Keyboard.current.wKey.isPressed)
        {
            vel.y += Speed / 2;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            vel.y -= Speed / 2;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            vel.x += Speed / 2;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            vel.x -= Speed / 2;
        }
        SetState(s);
        RB.linearVelocity = vel;
    }

    public void SetState(PlayerState s){
        if (State == s)return;
        State = s;
        if (State == PlayerState.Alive){
            Anim.Play("Alive");
        }
        else if (State == PlayerState.Dead){
            Anim.Play("Dead");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            Debug.Log("Hit");
            hit = true;
            Vector3 ghostSpawn = new Vector3(-9f, 0f, 0f);
            Instantiate(ghost, ghostSpawn, Quaternion.identity);
        }
        if (collision.gameObject.tag == "Flag")
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
