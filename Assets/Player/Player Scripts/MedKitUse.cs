using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedKitUse : MonoBehaviour
{
    public int maxMedKits = 3;
    public int currentMedKits = 3;
    public Text medKitText;

    private void Start()
    {
        if (medKitText == null)
        {
            medKitText = GameObject.Find("Med Kits").GetComponent<Text>();
        }
        UpdateMedKitText();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                HitByZombie hitByZombie = player.GetComponent<HitByZombie>();
                if (hitByZombie != null && hitByZombie.GetCurrentHealth() < 100 && currentMedKits >= 1)
                {
                    int healthToAdd = 100 - hitByZombie.GetCurrentHealth();
                    hitByZombie.RestoreHealth(healthToAdd);
                    currentMedKits--;
                    UpdateMedKitText();
                } else if (hitByZombie.GetCurrentHealth() == 100)
                {
                    Debug.Log("Health is not less than 100");
                } else if (hitByZombie == null)
                {
                    Debug.Log("hitByZombie is returning null");
                } else
                {
                    Debug.Log("Just not working FUCK YOU");
                }
            }
        }
    }
    public void UpdateMedKitText()
    {
        if (medKitText != null)
        {
            medKitText.text = "x " + currentMedKits;
        }
    }
}
