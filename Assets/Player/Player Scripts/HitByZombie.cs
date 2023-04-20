using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HitByZombie : MonoBehaviour
{
    [SerializeField]
    public static int maxHealth = 100;
    [SerializeField]
    public static int currentHealth;
    [SerializeField]
    private GameObject healthObject;

    private bool zombieIsTouching = false;
    public float timer = 1f;

    public Material flashMaterial;
    private List<SpriteRenderer> childSpriteRenderers = new List<SpriteRenderer>();
    private List<Material> originalMaterials = new List<Material>();



    void Start()
    {

        foreach (Transform child in transform)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                childSpriteRenderers.Add(spriteRenderer);
                originalMaterials.Add(spriteRenderer.material);
            }
        }

        healthObject = GameObject.Find("Health");
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    void Update()
    {

        UpdateHealthText();

        if (zombieIsTouching)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 1f;
                currentHealth -= 10;

                HitFlash();

                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                    Die();
                }
                
                UpdateHealthText();
            }
        }
    }

    public void HitFlash()
    {
            foreach (SpriteRenderer spriteRenderer in childSpriteRenderers)
            {
                spriteRenderer.material = flashMaterial;
            }

            Invoke("setPlayerMaterialToOriginal", 0.1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            zombieIsTouching = true;
            currentHealth -= 10;
            HitFlash();
            
            if (currentHealth <= 0)
            {
                currentHealth = 0;

                Die();
            }
            
            UpdateHealthText();
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            zombieIsTouching = false;
        }
    }

    public static void Die()
    {
        ZombieSpawns.countOfTotalZombies = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateHealthText()
    {
        Text healthText = healthObject.GetComponent<Text>();
        if (healthText != null)
        {
            healthText.text = currentHealth + " / 100";
        }

        
    }

    public void RestoreHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, 100);
        UpdateHealthText();
    }

    void setPlayerMaterialToOriginal()
    {
        for (int i = 0; i < childSpriteRenderers.Count; i++)
        {
            childSpriteRenderers[i].material = originalMaterials[i];
        }
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

}
