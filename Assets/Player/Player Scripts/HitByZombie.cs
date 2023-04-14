using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitByZombie : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject healthObject;
    public string zombieTag = "Zombie";

    void Start()
    {
        healthObject = GameObject.Find("Health");
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
            currentHealth -= 10;
            UpdateHealthText();
            if (currentHealth <= 0)
            {
                Die();
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
