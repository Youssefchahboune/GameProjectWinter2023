using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HitByZombie : MonoBehaviour
{
    [SerializeField]
    public static int maxHealth = 100; // the maximum health of the player (can be set in the inspector)
    [SerializeField]
    public static int currentHealth; // the current health of the player
    [SerializeField]
    private GameObject healthObject; // a reference to the health UI element

    [SerializeField]
    Canvas gameOverCanvas; // a reference to the game over canvas

    public LookAtMouse lookAtMouseScript;
    public Shooting shootingScript;
    public PlayerMove moveScript;

    // Reference to the AudioSource component
    public AudioSource audioSource;

    // Sound clip for the regen sound
    public AudioClip zombieHitClip;

    private bool zombieIsTouching = false; // flag for whether the player is touching a zombie
    public float timer = 1f; // a timer used for decreasing the player's health at a set interval

    public Material flashMaterial; // the material used for flashing the player sprite when hit
    private List<SpriteRenderer> childSpriteRenderers = new List<SpriteRenderer>(); // a list of all sprite renderers on child objects
    private List<Material> originalMaterials = new List<Material>(); // a list of the original materials for each sprite renderer

    // runs once when the script is first enabled
    void Start()
    {
        shootingScript = FindObjectOfType<Shooting>();
        lookAtMouseScript = FindObjectOfType<LookAtMouse>();
        moveScript = FindObjectOfType<PlayerMove>();
        // Get the AudioSource component attached to this game object
        audioSource = GetComponent<AudioSource>();

        // find all sprite renderers on child objects and store them in a list
        foreach (Transform child in transform)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                childSpriteRenderers.Add(spriteRenderer);
                originalMaterials.Add(spriteRenderer.material);
            }
        }

        // find the health UI element and set the current health to the maximum health
        healthObject = GameObject.Find("Health");
        currentHealth = maxHealth;
        UpdateHealthText();

    }

    // runs every frame
    void Update()
    {
        UpdateHealthText();

        // if the player is touching a zombie, decrease their health at a set interval
        if (zombieIsTouching)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 1f;
                currentHealth -= 10;
                // flash the player sprite to indicate damage taken
                HitFlash();

                // if the player's health reaches zero, run the Die function
                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                    //Die();
                    gameOverCanvas.enabled = true;
                    lookAtMouseScript.enabled = false;
                    shootingScript.enabled = false;
                    moveScript.enabled = false;

                }

                UpdateHealthText();
            }
        }
    }

    public void HitFlash()
    {
        if (currentHealth > 0)
        {
            // Change the material of all child SpriteRenderers to the flashMaterial
            foreach (SpriteRenderer spriteRenderer in childSpriteRenderers)
            {
                audioSource.PlayOneShot(zombieHitClip);
                spriteRenderer.material = flashMaterial;
            }

            // Schedule the material of all child SpriteRenderers to be reverted to their original material after 0.1 seconds
            Invoke("setPlayerMaterialToOriginal", 0.1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            // Player is colliding with a Zombie
            zombieIsTouching = true;
            currentHealth -= 10;
            HitFlash();
            MedKitUse.HealingEffect.SetActive(false);
            MedKitUse.mediInUseEffect.SetActive(false);

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                // Player died
                gameOverCanvas.enabled = true;
                lookAtMouseScript.enabled = false;
                shootingScript.enabled = false;
                moveScript.enabled = false;

            }

            UpdateHealthText();

        }
        else if (collision.gameObject.CompareTag("BigZombie"))
        {
            // Player is colliding with a BigZombie
            zombieIsTouching = true;
            currentHealth -= 25;
            HitFlash();
            MedKitUse.HealingEffect.SetActive(false);
            MedKitUse.mediInUseEffect.SetActive(false);

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                // Player died
                lookAtMouseScript.enabled = false;
                shootingScript.enabled = false;
                gameOverCanvas.enabled = true;
                moveScript.enabled = false;

            }

            UpdateHealthText();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie") || collision.gameObject.CompareTag("BigZombie"))
        {
            // Player stopped colliding with a Zombie or BigZombie
            zombieIsTouching = false;
        }
    }

    // This method updates the health text in the game UI based on the current health value
    void UpdateHealthText()
    {
        Text healthText = healthObject.GetComponent<Text>();
        if (healthText != null)
        {
            healthText.text = currentHealth + " / 100";
        }
    }

    // This method restores the player's health by the given amount, clamping it between 0 and 100
    public void RestoreHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, 100);
        UpdateHealthText();
    }

    // This method sets the material of all child sprite renderers back to their original materials after a hit flash
    void setPlayerMaterialToOriginal()
    {
        for (int i = 0; i < childSpriteRenderers.Count; i++)
        {
            childSpriteRenderers[i].material = originalMaterials[i];
        }
    }

    // This method returns the player's current health value
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
