using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float jumpForce;
    public float speed;

    private Vector3 velocity = Vector3.zero;
    public bool isGrounded;
    public GameObject groundCheck;

    public enum Direction
    {
        RIGHT,
        LEFT
    }

    private Direction direction = Direction.RIGHT;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            FacingDirection = Direction.RIGHT;
            Vector3 targetVelocity = new Vector2(speed, rb2d.velocity.y);

            rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref velocity, Time.fixedDeltaTime * 0.05f);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            FacingDirection = Direction.LEFT;
            Vector3 targetVelocity = new Vector2(-speed, rb2d.velocity.y);

            rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref velocity, Time.fixedDeltaTime * 0.05f);
        }

        if (Input.GetButtonDown("Jump") || Input.GetButton("Jump"))
        {
            if(isGrounded) {
                isGrounded = false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
        }
    }

    public Direction FacingDirection
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
