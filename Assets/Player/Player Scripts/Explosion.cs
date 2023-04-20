using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float radius = 1.5f;

    [SerializeField]
    private int grenadesHit;

    // Update is called once per frame
    private void Start()
    {
        grenadesHit= 0;
    }
    void Update()
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D col in enemyHit)
        {

            if (col.gameObject.CompareTag("Zombie"))
            {
                Destroy(col.gameObject);
                ZombieDies.countOfDeadZombies++;
                ZombieSpawns.countOfTotalZombies--;
                SetStartScore.currentScore += 10;
            } 
            else if (col.gameObject.CompareTag("BigZombie"))
            {
                if (grenadesHit == 2)
                {
                    Destroy(col.gameObject);
                    SetStartScore.currentScore += 10;
                    grenadesHit= 0;
                }
                grenadesHit++;
            }
            else if (col.gameObject.CompareTag("Player"))
            {
                HitByZombie.Die();
                break;
            }
            
        }
    }

    private void DestroyIt()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
