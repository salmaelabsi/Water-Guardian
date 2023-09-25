using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBounds : MonoBehaviour
{
    // Maximum movement to right, left, and down
    public float minX = -1.8f, maxX = 2.0f, minY = -7.0f;

    private bool outOfBounds;

    void Update()
    {
        // Check if the player object has been destroyed before performing any actions
        if (gameObject != null)
        {
            CheckBounds();
        }
    }

    private void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > maxX) // Don't allow right movement beyond max
        {
            temp.x = maxX;
        }

        if (temp.x < minX) // Don't allow left movement beyond min
        {
            temp.x = minX;
        }

        transform.position = temp; // Reset position of player

        if (temp.y <= minY) // If player drops below, then die
        {
            if (!outOfBounds)
            {
                outOfBounds = true;
                G4SoundManager.instance.DeathSound();

                // Check if the GameManager is not null before calling GameOver
                if (G4GameManager.instance != null)
                {
                    G4GameManager.instance.GameOver();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("TopSpike")) // If player hits top spikes, then die
        {
            transform.position = new Vector2(1000f, 1000f);
            G4SoundManager.instance.DeathSound();

            // Check if the GameManager is not null before calling GameOver
            if (G4GameManager.instance != null)
            {
                G4GameManager.instance.GameOver();
            }
        }
    }
}
//Code by Salma Elabsi