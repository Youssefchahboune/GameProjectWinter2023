// Import necessary modules
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define a class named DestroyBullet
public class DestroyBullet : MonoBehaviour
{
    // This function is called when the trigger collider attached to the bullet collides with another collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the tag of the collider matches any of these tags
        if (collision.CompareTag("Danger Tape") || collision.CompareTag("Ammo Station Indiv.") || collision.CompareTag("Crate"))
        {
            // If the tag matches, destroy the bullet gameobject
            Destroy(gameObject);
        }
    }
}
// This script destroys the bullet gameobject when it collides with specific colliders that have matching tags.