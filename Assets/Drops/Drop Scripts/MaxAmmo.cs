using UnityEngine;

public class MaxAmmo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player has collided with the MaxAmmo power-up.
        if (collision.CompareTag("Player"))
        {
            // Check if the player's current amount of bullets is less than the maximum allowed.
            if (Shooting.currentAmountOfBullet < Shooting.maxBullets)
            {
                // Calculate the amount of bullets to add to the player's current amount of bullets.
                int ammoToAdd = Shooting.maxBullets - Shooting.currentAmountOfBullet;
                // Increase the player's current amount of bullets by the calculated amount.
                Shooting.currentAmountOfBullet += ammoToAdd;
                // Update the bullet UI text to reflect the new current amount of bullets.
                Shooting.updateBulletText();
            }
            else
            {
                // If the player already has the maximum amount of bullets, add 250 points to their score.
                SetStartScore.currentScore += 250;
            }

            // Destroy the MaxAmmo power-up game object.
            Destroy(gameObject);
        }
    }
}
