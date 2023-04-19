using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] dropPrefab; 
    [SerializeField] float dropInterval = 30f;
    [SerializeField] float minXTras;
    [SerializeField] float maxXTras;
    [SerializeField] float minYTras;
    [SerializeField] float maxYTras;

    int lastDropIndex = -1;

    void Start()
    {
        StartCoroutine(DropSpawn());
    }

    IEnumerator DropSpawn()
    {
        int dropIndex = Random.Range(0, dropPrefab.Length);
        while(true)
        {
            while (dropIndex == lastDropIndex)
            {
                dropIndex = Random.Range(0, dropPrefab.Length);
            }
            lastDropIndex = dropIndex;

            var spawnXPosition = Random.Range(minXTras, minYTras);
            var spawnYPosition = Random.Range(minYTras, maxYTras);

            var position = new Vector2(spawnXPosition, spawnYPosition);

            GameObject gameObject = Instantiate(dropPrefab[dropIndex], position, Quaternion.identity);
            Destroy(gameObject, 10f);
            yield return new WaitForSeconds(dropInterval);
        }
    }
}
