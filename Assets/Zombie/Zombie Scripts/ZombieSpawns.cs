using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawns : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;

    public static int countOfTotalZombies;

    public static int countOfZombiesSpawned;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("getAllSpawners", 5f, 4f);
       
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }

    void getAllSpawners()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");

        if (countOfTotalZombies < 20)
        {
            foreach (GameObject spawner in spawners)
            {
                Instantiate(zombiePrefab, spawner.transform.position, Quaternion.identity);
                countOfTotalZombies++;
                countOfZombiesSpawned++;
                Debug.Log("Zombies spawned: " + countOfZombiesSpawned);
            }
           
        }
    }
    }

