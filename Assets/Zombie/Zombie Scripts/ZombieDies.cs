// Import necessary libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ZombieDies class, responsible for handling zombie's death
public class ZombieDies : MonoBehaviour
{
    // Zombie's health attributes
    [SerializeField] private int maxHealth; // The maximum amount of health the zombie can have
    [SerializeField] private int currentHealth; // The current amount of health the zombie has
    [SerializeField] private string bulletTag = "Bullet"; // The tag used to identify bullets

    // Sprite and material attributes used for flashing animation
    private List<SpriteRenderer> childSpriteRenderers = new List<SpriteRenderer>();
    private List<Material> originalMaterials = new List<Material>();
    public Material flashMaterial;

    // Variables used for tracking zombies' statistics
    public static int countOfDeadZombies; // The total amount of zombies that have died
    public GameObject bloodSplatter; // The blood particle effect to be played upon the zombie's death

    // Start is called before the first frame update
    void Start()
    {
        // Initialize zombie's health and find all sprite renderers on the zombie
        maxHealth = Random.Range(1, 3);
        currentHealth = maxHealth;

        foreach (Transform child in transform)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                childSpriteRenderers.Add(spriteRenderer);
                originalMaterials.Add(spriteRenderer.material);
            }
        }
    }

    // This function is called when the zombie collides with another object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the colliding object has the bulletTag, it means the zombie was hit by a bullet
        if (collision.gameObject.CompareTag(bulletTag))
        {
            // Destroy the bullet and reduce the zombie's health
            Destroy(collision.gameObject);
            currentHealth--;

            // Play the hit animation and instantiate a blood particle effect
            HitFlash();
            Instantiate(bloodSplatter, collision.gameObject.transform.position, Quaternion.identity);

            // If the zombie's health is zero or less, it dies
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    // This function is called when the zombie dies
    void Die()
    {
        // Increase the count of dead zombies and decrease the count of total zombies
        countOfDeadZombies++;
        ZombieSpawns.countOfTotalZombies--;

        // Destroy the zombie and log the total amounts of zombies and dead zombies
        Destroy(gameObject);
        Debug.Log("Total amount of zombies dead: " + countOfDeadZombies);
        Debug.Log("Total amount of zombies: " + ZombieSpawns.countOfTotalZombies);
    }

    // This function is called to play the hit animation
    public void HitFlash()
    {
        // Change all the sprite renderer's materials to the flash material
        foreach (SpriteRenderer spriteRenderer in childSpriteRenderers)
        {
            spriteRenderer.material = flashMaterial;
        }

        // Invoke the setPlayerMaterialToOriginal function after 0.1 seconds
        Invoke("setPlayerMaterialToOriginal", 0.1f);
    }

    // This function is called to revert the sprite renderer's materials to their original materials
    void setPlayerMaterialToOriginal()
    {
        for (int i = 0; i < childSpriteRenderers.Count; i++)
        {
            childSpriteRenderers[i].material = originalMaterials[i];
        }
    }
}
