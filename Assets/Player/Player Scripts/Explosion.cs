using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float radius = 1.5f;

    [SerializeField]
    private int grenadesHit =0;

    // Update is called once per frame
    private void Start()
    {
        
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
                if (grenadesHit == 3)
                {
                    Destroy(col.gameObject);
                    SetStartScore.currentScore += 50;
                    grenadesHit = 0; // reset the counter
                }
                else
                {
                    grenadesHit++;
                }
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
