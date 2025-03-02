using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public float initialSpeed = 5f;     // The initial speed at which the object runs
    public float decelerationRate = 0.1f;  // How much the speed decreases each second
    public float minimumSpeed = 1f;     // The minimum speed it can reach before stopping
    public float detectionRadius = 10f; // Radius within which the object detects the player

    private Transform playerTransform;  // Reference to the player's transform
    private float currentSpeed;         // Current speed of the object

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;  // Find the player by tag
        currentSpeed = initialSpeed;  // Set the initial speed
    }

    void Update()
    {
        // Check if the player is within the detection radius
        if (Vector2.Distance(transform.position, playerTransform.position) <= detectionRadius)
        {
            // Make the object run away from the player
            Vector2 direction = (transform.position - playerTransform.position).normalized;
            transform.Translate(direction * currentSpeed * Time.deltaTime);

            // Gradually decrease the speed over time (deceleration)
            currentSpeed = Mathf.Max(currentSpeed - decelerationRate * Time.deltaTime, minimumSpeed);
        }
    }

    // This method is called when the object collides with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with the player
        if (other.CompareTag("Player"))
        {
            // Destroy the object
            Destroy(gameObject);  // Remove this object from the scene
        }
    }
}
