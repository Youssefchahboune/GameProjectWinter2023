using UnityEngine;

public class MaxAmmo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (Shooting.currentAmountOfBullet < Shooting.maxBullets)
            {
                int ammoToAdd = Shooting.maxBullets - Shooting.currentAmountOfBullet;
                Shooting.currentAmountOfBullet += ammoToAdd;
                Shooting.updateBulletText();
            }
            else
            {
                // Add 250 points to score if player already has max bullets
                    
                   
                SetStartScore.currentScore += 250;
                   
            }

            Destroy(gameObject);
        }
    }
}
