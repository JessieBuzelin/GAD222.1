using UnityEngine;
using UnityEngine.SceneManagement;  // To load scenes

public class SceneChangeOnCollision : MonoBehaviour
{
    // This method is called when another collider enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))  // Make sure the player has the tag "Player"
        {
            // Load the scene named "Forest"
            SceneManager.LoadScene("Forest");
        }
    }
}

