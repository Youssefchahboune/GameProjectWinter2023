using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedKitUse : MonoBehaviour
{
    // static variables for the maximum and current amount of medkits
    public static int maxMedKit = 3;
    public static int currentAmountOfMedKit;

    // reference to the UI text object displaying the medkit count
    public Text medKitText;

    // reference to the game object representing the medkit in use
    public static GameObject mediInUseEffect;

    // reference to the game object representing the healing effect
    public static GameObject HealingEffect;

    // Reference to the AudioSource component
    public AudioSource audioSource;

    // Sound clip for the regen sound
    public AudioClip regenSoundClip;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the current amount of medkits to the maximum amount
        currentAmountOfMedKit = maxMedKit;

        // find the UI text object for the medkit count
        medKitText = GameObject.Find("Med Kits").GetComponent<Text>();

        // update the medkit count UI text
        medKitText.text = "x " + currentAmountOfMedKit;

        // find the game objects for the medkit in use and the healing effect
        mediInUseEffect = GameObject.FindGameObjectWithTag("Healing");
        HealingEffect = GameObject.FindGameObjectWithTag("Healing effect");

        // deactivate the medkit in use and the healing effect game objects
        mediInUseEffect.SetActive(false);
        HealingEffect.SetActive(false);

        // Get the AudioSource component attached to this game object
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // update the medkit count UI text
        UpdateMedkitText();

        // if the spacebar is pressed and there are medkits left and the player is not at full health
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentAmountOfMedKit > 0 && HitByZombie.currentHealth < 100)
            {
                // Play the regen sound clip
                audioSource.PlayOneShot(regenSoundClip);

                // activate the medkit in use and the healing effect game objects
                mediInUseEffect.SetActive(true);
                HealingEffect.SetActive(true);

                // invoke a method to deactivate the medkit in use and the healing effect game objects after 2 seconds
                Invoke("SetMedInUseEffectToFalse", 2f);
            }
        }
    }

    // updates the medkit count UI text
    void UpdateMedkitText()
    {
        medKitText.text = "x " + currentAmountOfMedKit;
    }

    // deactivates the medkit in use and the healing effect game objects and applies the medkit's healing effect to the player
    void SetMedInUseEffectToFalse()
    {
        // set the player's current health to the maximum health
        HitByZombie.currentHealth = HitByZombie.maxHealth;

        // decrease the current amount of medkits by 1
        currentAmountOfMedKit--;

        // deactivate the medkit in use and the healing effect game objects
        mediInUseEffect.SetActive(false);
        HealingEffect.SetActive(false);
    }
}
