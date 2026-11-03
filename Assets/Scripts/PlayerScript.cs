using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerState State = PlayerState.Alive;
    public Animator Anim;
    static public bool hit;
    public Rigidbody2D RB;
    private int Speed = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
            s = PlayerState.Dead;
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
}
