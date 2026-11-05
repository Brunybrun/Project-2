using UnityEngine;
using static PlayerScript;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class GhostPlayerScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public SpriteRenderer SR;
    private int Speed = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DeadPlayerMovement();
    }
    public void DeadPlayerMovement()
    {
        //PlayerState s = PlayerState.Dead;
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
            SR.flipX = false;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            vel.x -= Speed / 2;
            SR.flipX = true;
        }
        //SetState(s);
        RB.linearVelocity = vel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            PlayerScript.hit = false;
            Destroy(gameObject);
        }
    }
}
