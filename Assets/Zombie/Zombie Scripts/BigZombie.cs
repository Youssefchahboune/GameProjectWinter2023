using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] private string bulletTag = "Bullet";

    private List<SpriteRenderer> childSpriteRenderers = new List<SpriteRenderer>();
    private List<Material> originalMaterials = new List<Material>();
    public Material flashMaterial;


    public static int countOfBigDeadZombies;

    void Start()
    {
        maxHealth = 12;
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


    private void Update()
    {
        if (currentHealth <= 0) {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(bulletTag))
        {
            Destroy(collision.gameObject);

            currentHealth--;

            HitFlash();

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        ZombieDies.countOfDeadZombies++;
        SpawnBigZombie.NumberOfBigZombieCurrentlyOnTheMap--;
        Destroy(gameObject);
    }

    public void HitFlash()
    {
        foreach (SpriteRenderer spriteRenderer in childSpriteRenderers)
        {
            spriteRenderer.material = flashMaterial;
        }

        Invoke("setPlayerMaterialToOriginal", 0.1f);
    }

    void setPlayerMaterialToOriginal()
    {
        for (int i = 0; i < childSpriteRenderers.Count; i++)
        {
            childSpriteRenderers[i].material = originalMaterials[i];
        }
    }
}
