using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Danger Tape") || collision.CompareTag("Ammo Station") || collision.CompareTag("Crate"))
        {
            Destroy(gameObject);
        }
    }
}
