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
    public GameObject ghost;
    private float Speed = 6f;

    void Start()
    {
        //Ensures that the ghost will spawn outside of the level
        ghost.transform.position = GhostSpawn.spawnPosition;
    }

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
            vel.y += Speed / 2f;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            vel.y -= Speed / 2f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            vel.x += Speed / 2f;
            SR.flipX = false;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            vel.x -= Speed / 2f;
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
                //When the ghost collides with the player, the player returns to the intial spawnpoint
                PlayerScript.PRB.transform.position = PlayerSpawn.spawnPointPosition;
            }
            else if (GameManager.startAtSpawn == false)
            {
                //When the ghost collides with the player, the player retruns to the checkpoint
                PlayerScript.PRB.transform.position = CheckpointScript.checkpointPosition;
            }
            //Moves the outside of the level
            ghost.transform.position = GhostSpawn.spawnPosition;
        }
    }

    //If the ghost gets hit during any level, the game resets back to level 1
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            if (GameManager.tutorial)
            {
                ghost.transform.position = GhostSpawn.tutorialSpawnPosition;
            }
            else if (GameManager.tutorial == false)
            {
                SceneManager.LoadScene("Level 1");
                //GameManager.startAtSpawn = true;
            }
        }
    }
}
