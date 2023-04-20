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
    private int targetNum;

    void Start()
    {
        targetNum = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (ZombieDies.countOfDeadZombies == targetNum) {

            Spawn();
            targetNum += 5;
        }
    }

    void Spawn()
    {

        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        Instantiate(bigZombiePrefab, spawners[Random.Range(1, 5)].transform.position, Quaternion.identity);

    }
}
