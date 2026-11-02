using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerState State = PlayerState.Alive;
    public Animator Anim;
    static public bool hit;
    public Rigidbody2D RB;
    public int Speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
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
            s = PlayerState.Alive;
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
