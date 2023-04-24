using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour
{
    // The explosion prefab to instantiate when the nuke hits the player.
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player has picked up the nuke drop.
        if (collision.CompareTag("Player"))
        {
            // Find all game objects with the "Zombie" tag and destroy them while creating an explosion effect.
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            foreach (GameObject zombie in zombies)
            {
                Instantiate(explosion, zombie.transform.position, Quaternion.identity);
                Destroy(zombie);
                ZombieDies.countOfDeadZombies++;
                Debug.Log(ZombieDies.countOfDeadZombies);
            }

            // Add 400 points to the player's score.
            SetStartScore.currentScore += 400;

            // Reset the count of total zombies to zero.
            ZombieSpawns.countOfTotalZombies = 0;

            // Destroy the nuke game object.
            Destroy(gameObject);
        }
    }
}
