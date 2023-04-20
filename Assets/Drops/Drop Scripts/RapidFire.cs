using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RapidFire : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Shooting.bulletsLeftText.gameObject.SetActive(false);
            Shooting.infiniteBulletsText.gameObject.SetActive(true);
            Shooting.isRapidFireActive = true;
            Destroy(gameObject);
        }
    }
}
