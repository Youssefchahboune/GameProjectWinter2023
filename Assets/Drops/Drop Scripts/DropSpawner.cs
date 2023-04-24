using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    // An array of different types of game objects that can be spawned as drops.
    [SerializeField] GameObject[] dropPrefab;

    // Time interval between drops.
    [SerializeField] float dropInterval = 45f;

    // Minimum and maximum X and Y positions where drops can be spawned.
    [SerializeField] float minXTras;
    [SerializeField] float maxXTras;
    [SerializeField] float minYTras;
    [SerializeField] float maxYTras;

    // Index of the last spawned drop object.
    int lastDropIndex = -1;

    void Start()
    {
        // Start the DropSpawn coroutine when the object is created.
        StartCoroutine(DropSpawn());
    }

    IEnumerator DropSpawn()
    {
        // Wait for 10 seconds before spawning the first object.
        yield return new WaitForSeconds(10f);

        // Pick a random object from the dropPrefab array.
        int dropIndex = Random.Range(0, dropPrefab.Length);

        // Loop forever, spawning drops at regular intervals.
        while (true)
        {
            // If the same object was spawned last time, pick a new one.
            while (dropIndex == lastDropIndex)
            {
                dropIndex = Random.Range(0, dropPrefab.Length);
            }
            lastDropIndex = dropIndex;

            // Try to find a valid position to spawn the drop.
            bool isPositionValid = false;
            Vector2 position = Vector2.zero;
            while (!isPositionValid)
            {
                position = GetRandomPosition();

                // Check if there are any crates or ammo stations at the spawn position of the drop.
                Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1f);
                isPositionValid = true;

                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("Crate") || collider.CompareTag("Ammo Station"))
                    {
                        isPositionValid = false;
                        break;
                    }
                }
            }

            // Create a new instance of the dropPrefab at the chosen position.
            GameObject gameObject = Instantiate(dropPrefab[dropIndex], position, Quaternion.identity);

            // Destroy the dropPrefab object after 20 seconds if not picked up by player.
            Destroy(gameObject, 20f);

            // Wait for the specified drop interval before spawning the next object.
            yield return new WaitForSeconds(dropInterval);
        }
    }

    // Returns a random position within the bounds defined by minXTras, maxXTras, minYTras, and maxYTras.
    private Vector2 GetRandomPosition()
    {
        float spawnXPosition = Random.Range(minXTras, maxXTras);
        float spawnYPosition = Random.Range(minYTras, maxYTras);
        return new Vector2(spawnXPosition, spawnYPosition);
    }
}