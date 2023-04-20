using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float radius = 1.5f;

    public int GrenadeDamage = 4;


    // Update is called once per frame
    private void Start()
    {
        ZoneDamage();
    }

    public void ZoneDamage()
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll( transform.position, radius);
        foreach(Collider2D col in enemyHit)
        {

            if (col.gameObject.CompareTag("Zombie"))
            {
                Destroy(col.gameObject);
               
                ZombieDies.countOfDeadZombies++;
                ZombieSpawns.countOfTotalZombies--;
                SetStartScore.currentScore += 10;
            }
            else if (col.gameObject.CompareTag("Player"))
            {
                HitByZombie.Die();
                break;
            }else if (col.gameObject.CompareTag("BigZombie"))
            {
                NewBehaviourScript bigZombieScript = col.gameObject.GetComponent<NewBehaviourScript>();
                bigZombieScript.currentHealth -= GrenadeDamage;
                bigZombieScript.HitFlash();

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
