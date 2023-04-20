using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour
{
    public GameObject explosion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            foreach (GameObject zombie in zombies)
            {
                Instantiate(explosion, zombie.transform.position, Quaternion.identity);
                Destroy(zombie);
                ZombieDies.countOfDeadZombies++;
                Debug.Log(ZombieDies.countOfDeadZombies);
            }

            SetStartScore.currentScore += 400;
            
            ZombieSpawns.countOfTotalZombies = 0;
            Destroy(gameObject);

        }
    }
}
