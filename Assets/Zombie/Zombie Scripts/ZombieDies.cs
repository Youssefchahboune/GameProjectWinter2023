using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDies : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public string bulletTag = "Bullet";

    void Start()
    {
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
  
        Destroy(gameObject, 0.5f);
    }
}
