using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] dropPrefab;
    [SerializeField] float dropInterval = 45f;
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
        yield return new WaitForSeconds(10f);
        int dropIndex = Random.Range(0, dropPrefab.Length);
        while (true)
        {
            while (dropIndex == lastDropIndex)
            {
                dropIndex = Random.Range(0, dropPrefab.Length);
            }
            lastDropIndex = dropIndex;

            bool isPositionValid = false;
            Vector2 position = Vector2.zero;
            while (!isPositionValid)
            {
                position = GetRandomPosition();

                Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1f);
                isPositionValid = true;

                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("Crate") || collider.CompareTag("Ammo Station"))
                    {
                        isPositionValid = false;
                        break;
                    }
                }
            }

            GameObject gameObject = Instantiate(dropPrefab[dropIndex], position, Quaternion.identity);
            Destroy(gameObject, 20f);

            yield return new WaitForSeconds(dropInterval);
        }
    }

    private Vector2 GetRandomPosition()
    {
        float spawnXPosition = Random.Range(minXTras, maxXTras);
        float spawnYPosition = Random.Range(minYTras, maxYTras);
        return new Vector2(spawnXPosition, spawnYPosition);
    }
}
