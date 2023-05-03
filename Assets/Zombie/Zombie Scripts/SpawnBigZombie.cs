using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBigZombie : MonoBehaviour
{
    [SerializeField]
    private GameObject bigZombiePrefab;

    public int LimitOfBZOnTheMap = 1;
    public static int NumberOfBigZombieCurrentlyOnTheMap = 0;

    void Start()
    {
        // Spawns a Big Zombie every 10 seconds after the start of the game
        InvokeRepeating("Spawn", 10f, 10f);
    }
    void Spawn()
    {
        // If there are no Big Zombies currently on the map
        if (NumberOfBigZombieCurrentlyOnTheMap == 0)
        {
            // Find all objects with the "Spawner" tag
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");

            // Spawn the number of Big Zombies specified by "LimitOfBZOnTheMap"
            for (int i = 0; i < LimitOfBZOnTheMap; i++)
            {
                // Instantiate a Big Zombie prefab at a random spawner location
                Instantiate(bigZombiePrefab, spawners[Random.Range(1, 5)].transform.position, Quaternion.identity);
                // Increase the count of Big Zombies currently on the map
                NumberOfBigZombieCurrentlyOnTheMap++;
            }
        }
    }
}
