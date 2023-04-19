using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawns : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;
  
    // Start is called before the first frame update
    void Start()
    {
       
        // Call SpawnZombies every 6 seconds
        InvokeRepeating("SpawnZombies", 5f, 6f);
    }

    void SpawnZombies()
    {
        
            Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
