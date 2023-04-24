using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RapidFire : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player has collided with the RapidFire power-up.
        if (collision.CompareTag("Player"))
        {
            // Disable the bullets left UI text and enable the infinite bullets UI text.
            Shooting.bulletsLeftText.gameObject.SetActive(false);
            Shooting.infiniteBulletsText.gameObject.SetActive(true);
            // Set the isRapidFireActive flag to true.
            Shooting.isRapidFireActive = true;
            // Destroy the RapidFire power-up game object.
            Destroy(gameObject);
        }
    }
}
