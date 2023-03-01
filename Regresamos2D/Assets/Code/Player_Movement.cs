using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public static Player_Movement instance;

    Rigidbody2D rb;
    public float movementSpeed;
    public float JumpSpeed;
    public Animator anim;
    public SpriteRenderer render;

    public Checkpoint checkpoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            render.flipX = true;
            anim.SetBool("Run", true);
        }
        else if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            render.flipX = false;
            anim.SetBool("Run", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("Run", false);
        }
        if (Input.GetKey("space") && IsGrounded.isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            transform.position = checkpoint.spawnpoint;
        }
        if(other.gameObject.tag == "checkpoint")
        {
            checkpoint = other.GetComponent<Checkpoint>();
            checkpoint.gameObject.SetActive(false);
        }
    }

}
