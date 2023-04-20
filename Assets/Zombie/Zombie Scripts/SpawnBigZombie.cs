using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBigZombie : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject bigZombiePrefab;


    public int LimitOfBZOnTheMap = 1;

    public static int NumberOfBigZombieCurrentlyOnTheMap = 0;

    void Start()
    {
        InvokeRepeating("Spawn", 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {

        if (NumberOfBigZombieCurrentlyOnTheMap == 0)
        {
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");

            for(int i = 0; i < LimitOfBZOnTheMap ; i++) { 
                Instantiate(bigZombiePrefab, spawners[Random.Range(1, 5)].transform.position, Quaternion.identity);
                NumberOfBigZombieCurrentlyOnTheMap++;
            }

        }
        

    }
}
