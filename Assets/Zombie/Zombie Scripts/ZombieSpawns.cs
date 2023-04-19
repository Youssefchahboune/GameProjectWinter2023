using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawns : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;
    [SerializeField]
    private int minZombies = 1;
    [SerializeField]
    private int maxZombies = 3;
    // Start is called before the first frame update
    void Start()
    {
        // Call SpawnZombies every 5 seconds
        InvokeRepeating("SpawnZombies", 5f, 5f);
    }

    void SpawnZombies()
    {
        int numZombies = Random.Range(minZombies, maxZombies);

        for (int i = 0; i < numZombies; i++)
        {
            Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
