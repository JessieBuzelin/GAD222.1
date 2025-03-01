using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // The movement speed of the player
    private Rigidbody2D rb;       // Reference to the Rigidbody2D component

    private Vector2 moveDirection;  // Direction the player is moving

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component attached to the player
    }

    void Update()
    {
        // Get movement input from the player (WASD or Arrow keys)
        float moveX = Input.GetAxisRaw("Horizontal");  // -1 for left, 1 for right
        float moveY = Input.GetAxisRaw("Vertical");    // -1 for down, 1 for up

        moveDirection = new Vector2(moveX, moveY).normalized;  // Normalize direction to avoid faster diagonal movement
    }

    void FixedUpdate()
    {
        // Move the player by applying velocity to the Rigidbody2D
        rb.velocity = moveDirection * moveSpeed;  // Move player with constant speed in the desired direction
    }
}

