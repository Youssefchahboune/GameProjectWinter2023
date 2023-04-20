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
    [SerializeField]
    private Boolean isSpawned50 = false;
    private Boolean isSpawned100 = false;

    void Start()
    {
        isSpawned50 = false; 
        isSpawned100=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ZombieDies.countOfDeadZombies == 5 && isSpawned50==false)
        {
            isSpawned50= true;
            Spawn();
        }

        else if (ZombieDies.countOfDeadZombies == 10 && isSpawned100 == false)
        {
            isSpawned100 = true;
            Spawn();
        }
    }

    void Spawn()
    {

        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        Instantiate(bigZombiePrefab, spawners[Random.Range(1, 5)].transform.position, Quaternion.identity);

    }
}
