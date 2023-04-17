using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public GameObject[] drops; // an array of the 4 drops to be randomly selected
    public float dropInterval = 30f; // the interval in seconds between drops

    private int lastDropIndex = -1; // the index of the last drop that was spawned
    private bool isSpawning = false; // a flag indicating whether a drop is currently being spawned

    void Start()
    {
        StartCoroutine(SpawnDrops());
    }

    IEnumerator SpawnDrops()
    {
        while (true)
        {
            if (!isSpawning)
            {
                isSpawning = true;

                // Choose a random drop index that is not the same as the last one
                int dropIndex = Random.Range(0, drops.Length);
                while (dropIndex == lastDropIndex)
                {
                    dropIndex = Random.Range(0, drops.Length);
                }
                lastDropIndex = dropIndex;

                // Choose a random position for the drop
                Vector3 dropPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));

                // Spawn the drop at the chosen position
                Instantiate(drops[dropIndex], dropPosition, Quaternion.identity);

                yield return new WaitForSeconds(dropInterval);

                isSpawning = false;
            }
            else
            {
                yield return null;
            }
        }
    }
}
