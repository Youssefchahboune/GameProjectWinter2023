using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDies : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private string bulletTag = "Bullet";

    void Start()
    {
        maxHealth = Random.Range(1, 4);
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(bulletTag))
        {
            Destroy(collision.gameObject);

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
