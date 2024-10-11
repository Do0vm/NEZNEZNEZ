using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 9f;
    public float jumpForce = 6f;
    private bool isGrounded = true; // Track whether the player is grounded

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Cache the components to avoid calling GetComponent() every frame
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded (simple example: check if vertical velocity is zero)
        isGrounded = Mathf.Abs(rb.velocity.y) < 0.001f;

        // Handle movement and flipping
        HandleMovement();

        // Handle jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Handle crouching
        if (Input.GetKeyDown(KeyCode.C))
        {
            Crouch();
        }
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput > 0) // Moving right
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Walking", true);
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (moveInput < 0) // Moving left
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Walking", true);
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else
        {
            animator.SetBool("Walking", false); // Not moving
        }
    }

    void Jump()
    {
        animator.SetTrigger("Jump");
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Preserve horizontal velocity while jumping
    }

    void Crouch()
    {
        animator.SetTrigger("Crouch");
    }
}
