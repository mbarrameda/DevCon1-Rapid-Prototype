using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player movement
    public float gravityStrength = 9.81f; // Strength of gravity

    private Rigidbody2D rb;
    private Vector2 gravityDirection = Vector2.down; // Initial gravity direction

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check gravity direction and apply movement accordingly
        if (gravityDirection == Vector2.left || gravityDirection == Vector2.right)
        {
            // Vertical movement when gravity is left or right (W/S or Up/Down keys)
            float moveInput = Input.GetAxisRaw("Vertical"); // -1 for S/DownArrow, 1 for W/UpArrow
            rb.velocity = new Vector2(rb.velocity.x, moveInput * moveSpeed);
        }
        else
        {
            // Horizontal movement when gravity is up or down (A/D keys)
            float moveInput = Input.GetAxisRaw("Horizontal"); // -1 for A, 1 for D
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }

        // Change gravity direction with arrow keys
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gravityDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gravityDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gravityDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gravityDirection = Vector2.right;
        }

        // Apply the new gravity direction
        Physics2D.gravity = gravityDirection * gravityStrength;
    }
}
