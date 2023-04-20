using UnityEngine;

public class MaxAmmo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Shooting shooting = collision.GetComponent<Shooting>();

            if (shooting != null)
            {
                if (Shooting.currentAmountOfBullet < Shooting.maxBulllets)
                {
                    int ammoToAdd = Shooting.maxBulllets - Shooting.currentAmountOfBullet;
                    Shooting.currentAmountOfBullet += ammoToAdd;
                    shooting.bulletsLeftText.text = Shooting.currentAmountOfBullet.ToString() + " / " + Shooting.maxBulllets.ToString();
                }
                else
                {
                    // Add 250 points to score if player already has max bullets
                    
                   
                    SetStartScore.currentScore += 250;
                   
                }
            }

            Destroy(gameObject);
        }
    }
}
