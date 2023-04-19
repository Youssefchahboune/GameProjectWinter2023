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
                int ammoToAdd = Shooting.maxBulllets - Shooting.currentAmountOfBullet;
                Shooting.currentAmountOfBullet += ammoToAdd;
                shooting.bulletsLeftText.text = Shooting.currentAmountOfBullet.ToString() + " / " + Shooting.maxBulllets.ToString();
            }

            Destroy(gameObject);
        }
    }
}
