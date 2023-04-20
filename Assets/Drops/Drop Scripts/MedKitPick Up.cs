using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(MedKitUse.currentAmountOfMedKit == 3)
            {
                SetStartScore.currentScore += 250;
            } else
            {
                MedKitUse.currentAmountOfMedKit++;
            }

            Destroy(gameObject);
        }
        
    }
}
