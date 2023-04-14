using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDies : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public string bulletTag = "Bullet";

    void Start()
    {
        maxHealth = Random.Range(1, 4);
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(bulletTag))
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
  
        Destroy(gameObject);
    }
}
