using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitUse : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                HitByZombie hitByZombie = player.GetComponent<HitByZombie>();
                MedKit medKit = FindObjectOfType<MedKit>();
                if (hitByZombie != null && hitByZombie.GetCurrentHealth() < 100 && medKit != null && medKit.currentMedKits >= 1)
                {
                    int healthToAdd = 100 - hitByZombie.GetCurrentHealth();
                    hitByZombie.RestoreHealth(healthToAdd);
                    medKit.currentMedKits--;
                    medKit.UpdateMedKitText();
                } else if (hitByZombie.GetCurrentHealth() == 100)
                {
                    Debug.Log("Health is not less than 100");
                } else if (hitByZombie == null)
                {
                    Debug.Log("hitByZombie is returning null");
                } else if (medKit == null)
                {
                    Debug.Log("medKit is returning null");
                }
            }
        }
    }
}
