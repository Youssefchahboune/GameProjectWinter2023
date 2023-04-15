using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitByZombie : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private GameObject healthObject;


    void Start()
    {
        healthObject = GameObject.Find("Health");
        currentHealth = maxHealth;
        UpdateHealthText();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            currentHealth -= 10;
            UpdateHealthText();
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        // Play death animation or sound
        // Restart the level or show game over screen
    }

    void UpdateHealthText()
    {
        Text healthText = healthObject.GetComponent<Text>();
        if (healthText != null)
        {
            healthText.text = currentHealth + "/ 100";
        }
    }
}
