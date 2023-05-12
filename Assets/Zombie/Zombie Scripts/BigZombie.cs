using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Serialized fields can be edited in the Inspector without making them public.
    [SerializeField] private int maxHealth; // The maximum health of the zombie.
    [SerializeField] public int currentHealth; // The current health of the zombie (can be accessed from other scripts).
    [SerializeField] private string bulletTag = "Bullet"; // The tag assigned to the bullet game object.

    // Lists to store the sprite renderers and their original materials for hit flash effect.
    private List<SpriteRenderer> childSpriteRenderers = new List<SpriteRenderer>();
    private List<Material> originalMaterials = new List<Material>();
    public Material flashMaterial; // The material used for hit flash effect.

    // Static variable to keep track of the number of big dead zombies.
    public static int countOfBigDeadZombies;

    // The particle effect game object for blood when the zombie gets hit.
    public GameObject bloodParticle;

    // Reference to the AudioSource component
    public AudioSource audioSource;

    // Sound clip for the big zombie death sound
    public AudioClip bigZombieSoundClip;

    // This method is called at the start of the game.
    void Start()
    {
        // Get the AudioSource component attached to this game object
        audioSource = GetComponent<AudioSource>();

        maxHealth = 12; // Assigning the maximum health value.
        currentHealth = maxHealth; // Assigning the current health value to the maximum health value.

        // This loop finds all the sprite renderers in the zombie and stores them along with their original materials.
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

    // This method is called every frame of the game.
    private void Update()
    {
        // If the zombie's current health is less than or equal to zero, it dies.
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // This method is called when the zombie collides with a trigger collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the collider's tag matches the bullet tag, the bullet is destroyed, the zombie's health is reduced, and the hit flash effect is shown.
        if (collision.gameObject.CompareTag(bulletTag))
        {
            Destroy(collision.gameObject);

            currentHealth--;

            HitFlash();

            Instantiate(bloodParticle, collision.gameObject.transform.position, Quaternion.identity);

            // If the zombie's current health is less than or equal to zero, it dies.
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    // This method is called when the zombie dies.
    void Die()
    {
        audioSource.PlayOneShot(bigZombieSoundClip);
        // Increment the count of dead zombies.
        ZombieDies.countOfDeadZombies++;

        // Decrement the count of big zombies currently on the map.
        SpawnBigZombie.NumberOfBigZombieCurrentlyOnTheMap--;

        // Destroy the zombie game object.
        Destroy(gameObject);
    }

    // This method is called to show the hit flash effect.
    public void HitFlash()
    {
        // Loop through all the sprite renderers and change their materials to the flash material.
        foreach (SpriteRenderer spriteRenderer in childSpriteRenderers)
        {
            spriteRenderer.material = flashMaterial;
        }

        // After a brief delay, reset all the sprite renderers to their original materials.
        Invoke("setPlayerMaterialToOriginal", 0.1f);
    }

    void setPlayerMaterialToOriginal()
    {
        // Loop through each child sprite renderer
        for (int i = 0; i < childSpriteRenderers.Count; i++)
        {
            // Set the material of the sprite renderer to its original material
            childSpriteRenderers[i].material = originalMaterials[i];
        }
    }
}
