using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedKitUse : MonoBehaviour
{

    public static int maxMedKit = 3;
    public static int currentAmountOfMedKit;
    public Text medKitText;

    public static GameObject mediInUseEffect;
    public static GameObject HealingEffect;


    // Start is called before the first frame update
    void Start()
    {
        currentAmountOfMedKit = maxMedKit;
        medKitText = GameObject.Find("Med Kits").GetComponent<Text>();
        medKitText.text = "x " + currentAmountOfMedKit;
        mediInUseEffect = GameObject.FindGameObjectWithTag("Healing");
        HealingEffect = GameObject.FindGameObjectWithTag("Healing effect");
        mediInUseEffect.SetActive(false);
        HealingEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        UpdateMedkitText();

        if(Input.GetKeyDown(KeyCode.Space)) {

            if(currentAmountOfMedKit > 0 && HitByZombie.currentHealth < 100)
            {
                HitByZombie.currentHealth = HitByZombie.maxHealth;
                mediInUseEffect.SetActive(true);
                HealingEffect.SetActive(true);
                Invoke("setMedInUseEffectToFalse", 2f);
                currentAmountOfMedKit--;
            }
        
        }
    }

    void UpdateMedkitText()
    {
        medKitText.text = "x " + currentAmountOfMedKit;
    }

    void setMedInUseEffectToFalse()
    {
        mediInUseEffect.SetActive(false);
        HealingEffect.SetActive(false);
    }
}
