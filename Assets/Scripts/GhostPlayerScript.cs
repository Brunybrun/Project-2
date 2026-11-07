using UnityEngine;
using static PlayerScript;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class GhostPlayerScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public SpriteRenderer SR;
    private int Speed = 4;
    public GameObject ghost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ghost.transform.position = GhostSpawn.spawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.hit)
        {
            DeadPlayerMovement();
        }
        else if (PlayerScript.hit == false)
        {
            RB.linearVelocity = Vector2.zero;
        }
    }
    public void DeadPlayerMovement()
    {
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
        RB.linearVelocity = vel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("I'm Alive!");
            PlayerScript.hit = false;
            if (GameManager.startAtSpawn)
            {
                PlayerScript.PRB.transform.position = PlayerSpawn.spawnPointPosition;
            }
            else if (GameManager.startAtSpawn == false)
            {
                PlayerScript.PRB.transform.position = CheckpointScript.checkpointPosition;
            }
            ghost.transform.position = GhostSpawn.spawnPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("Level 1");
            //GameManager.startAtSpawn = true;
        }
    }
}
