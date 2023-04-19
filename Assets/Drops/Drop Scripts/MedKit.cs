using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedKit : MonoBehaviour
{
    public int maxMedKits = 3;
    public Text medKitText;
    public int currentMedKits = 3;

    private void Start()
    {
        if (medKitText == null)
        {
            medKitText = GameObject.Find("Med Kits").GetComponent<Text>();
        }
        UpdateMedKitText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (currentMedKits < maxMedKits)
            {
                currentMedKits += 1;
                UpdateMedKitText();
            }
            else if (currentMedKits == maxMedKits)
            {
                AddScore score = FindObjectOfType<AddScore>();
                if (score != null)
                {
                    score.AddPoints(250);
                }
            }
            Destroy(gameObject);
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
