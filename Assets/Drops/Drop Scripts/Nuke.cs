using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            foreach (GameObject zombie in zombies)
            {
                Destroy(zombie);
                ZombieDies.countOfDeadZombies++;
                Debug.Log(ZombieDies.countOfDeadZombies);
            }

            SetStartScore.currentScore += 400;
            
            ZombieSpawns.count = 0;
            Destroy(gameObject);

        }
    }
}
