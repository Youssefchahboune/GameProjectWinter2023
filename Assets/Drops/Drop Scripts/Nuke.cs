using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);

            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            foreach (GameObject zombie in zombies)
            {
                Destroy(zombie);
            }
        }
    }
}
