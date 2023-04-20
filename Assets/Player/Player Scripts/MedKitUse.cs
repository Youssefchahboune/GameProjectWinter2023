using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedKitUse : MonoBehaviour
{

    public static int maxMedKit = 3;
    public static int currentAmountOfMedKit;
    public Text medKitText;


    // Start is called before the first frame update
    void Start()
    {
        currentAmountOfMedKit = maxMedKit;
        medKitText = GameObject.Find("Med Kits").GetComponent<Text>();
        medKitText.text = "x " + currentAmountOfMedKit;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMedkitText();

        if(Input.GetKeyDown(KeyCode.Space)) {

            if(currentAmountOfMedKit > 0 && HitByZombie.currentHealth < 100)
            {
                HitByZombie.currentHealth = HitByZombie.maxHealth;
                currentAmountOfMedKit--;
            }
        
        }
    }

    void UpdateMedkitText()
    {
        medKitText.text = "x " + currentAmountOfMedKit;
    }
}
