using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawns : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab; // Prefab for the zombie that will be spawned.

    public static int countOfTotalZombies; // Static variable to keep track of the total number of zombies spawned.
    public static int countOfZombiesSpawned; // Static variable to keep track of the number of zombies spawned in the current wave.

    void Start()
    {
        // Repeatedly call getAllSpawners() every 5 seconds, starting after 5 seconds have passed.
        InvokeRepeating("getAllSpawners", 5f, 5f);
    }

    void getAllSpawners()
    {
        // Find all GameObjects with the "Spawner" tag.
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");

        if (countOfTotalZombies < 20) // If the total number of zombies spawned is less than 20...
        {
            foreach (GameObject spawner in spawners) // ...for each spawner...
            {
                Instantiate(zombiePrefab, spawner.transform.position, Quaternion.identity); // ...instantiate a zombie at the spawner's position.
                countOfTotalZombies++; // Increase the total number of zombies spawned.
                countOfZombiesSpawned++; // Increase the number of zombies spawned in the current wave.
                Debug.Log("Zombies spawned: " + countOfZombiesSpawned); // Print the number of zombies spawned in the current wave.
            }
        }
    }
}
