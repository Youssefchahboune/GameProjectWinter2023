using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    public int healthAmount = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HitByZombie hitByZombie = collision.GetComponent<HitByZombie>();
            if (hitByZombie != null)
            {
                hitByZombie.RestoreHealth(healthAmount);
            }
            Destroy(gameObject);
        }
    }
}
