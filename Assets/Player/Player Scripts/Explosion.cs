// Import necessary modules
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define a public class called Explosion
public class Explosion : MonoBehaviour
{
    // Set the radius of the explosion as 1.5 by default
    [SerializeField]
    private float radius = 1.5f;

    // Set the amount of damage the grenade will inflict on the enemy as 4
    public int GrenadeDamage = 4;

    // Reference to the AudioSource component
    public AudioSource audioSource;

    // Sound clip for the frag sound
    public AudioClip fragSoundClip;

    // When the object is created, call the ZoneDamage function
    private void Start()
    {
        ZoneDamage();
        // Get the AudioSource component attached to this game object
        audioSource = GetComponent<AudioSource>();

    }

    // Function to calculate damage in a circular area of radius "radius"
    public void ZoneDamage()
    {

        // Find all the colliders inside the circular area and store them in "enemyHit" list
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(transform.position, radius);

        // For each collider in "enemyHit" list, do the following
        foreach (Collider2D col in enemyHit)
        {
            // If the collider belongs to the Zombie game object
            if (col.gameObject.CompareTag("Zombie"))
            {
                // Destroy the Zombie game object
                Destroy(col.gameObject);

                // Increase the count of dead Zombies and decrease the count of total Zombies
                ZombieDies.countOfDeadZombies++;
                ZombieSpawns.countOfTotalZombies--;

                // Increase the current score by 10 points
                SetStartScore.currentScore += 10;
            }
            // If the collider belongs to the Player game object
            else if (col.gameObject.CompareTag("Player"))
            {
                // Kill the player
                HitByZombie.currentHealth = 0;
                break;
            }
            // If the collider belongs to the BigZombie game object
            else if (col.gameObject.CompareTag("BigZombie"))
            {
                // Get the script attached to the BigZombie game object
                NewBehaviourScript bigZombieScript = col.gameObject.GetComponent<NewBehaviourScript>();

                // Decrease the health of the BigZombie game object by "GrenadeDamage"
                bigZombieScript.currentHealth -= GrenadeDamage;

                // Flash the sprite of the BigZombie game object to indicate damage
                bigZombieScript.HitFlash();
            }

        }
        audioSource.PlayOneShot(fragSoundClip);
    }

    // Function to destroy the object
    private void DestroyIt()
    {
        Destroy(gameObject);
    }

    // Function to draw a circular gizmo in the Unity editor for easy visualization of the explosion radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, radius);
    }

}
