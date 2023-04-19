using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawns : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;

    public static int count;
  
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("getAllSpawners", 5f, 5f);
       
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }

    void getAllSpawners()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");

        if (count < 20)
        {
            foreach (GameObject spawner in spawners)
            {
                Instantiate(zombiePrefab, spawner.transform.position, Quaternion.identity);
                count++;
            }
            Debug.Log(count);
        }
    }
    }

