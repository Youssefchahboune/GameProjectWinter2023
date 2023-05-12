using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// The Shooting class is responsible for managing the player's bullets and shooting behavior.
public class Shooting : MonoBehaviour
{
    // The speed at which bullets travel.
    public float bulletSpeed;

    // The prefab for the bullet object.
    public GameObject bulletPrefab;

    // The location where bullets are spawned from.
    public GameObject firePoint;

    // The particle effect that plays when the player shoots.
    public GameObject gunFire;

    // The animator component for the player character.
    public Animator anim;

    // The prefab for the grenade object.
    public GameObject grenade;

    // The maximum number of bullets the player can carry.
    public static int maxBullets = 100;

    // The current number of bullets the player has.
    public static int currentAmountOfBullet;

    // The UI text element that displays the current number of bullets.
    public static Text bulletsLeftText;

    // The total number of bullets that have been fired.
    public static int bulletsShot;

    // The UI text element that displays whether the player has infinite bullets or not.
    public static Text infiniteBulletsText;

    // The maximum number of grenades the player can carry.
    public static int maxGrenades = 3;

    // The current number of grenades the player has.
    public static int currentAmountOfGrenade;

    // The UI text element that displays the current number of grenades.
    public static Text grenadeLeftText;

    // Whether the rapid fire power-up is currently active or not.
    public static bool isRapidFireActive = false;

    // The time of the last bullet fired when in rapid fire mode.
    private float lastFireTime = 0f;

    // The rate at which bullets are fired when in rapid fire mode.
    private float fireRate = 0.1f;

    // The audio source component to play shooting sound.
    private AudioSource audioSource;

    // The AudioClip containing the bullet sound
    public AudioClip shootSound;

    // Called when the game starts.
    void Start()
    {
        // Get references to all necessary UI elements.
        bulletsLeftText = GameObject.Find("BulletsLeft").GetComponent<Text>();
        grenadeLeftText = GameObject.Find("Grenades").GetComponent<Text>();
        infiniteBulletsText = GameObject.Find("InfiniteBullets").GetComponent<Text>();

        // Hide the infinite bullets text by default.
        infiniteBulletsText.gameObject.SetActive(false);

        // Initialize the number of bullets and grenades.
        currentAmountOfBullet = maxBullets;
        updateBulletText();
        currentAmountOfGrenade = maxGrenades;
        updateGrenadeText();

        // Get the audio source component.
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = shootSound;
    }

    // Update is called once per frame
    void Update()
    {
        // If rapid fire is not active
        if (!isRapidFireActive)
        {
            // Check if left mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                // Check if there are bullets left
                if (currentAmountOfBullet > 0)
                {
                    // Shoot a bullet
                    shootBullet();
                    // Show gun fire effect
                    gunFire.SetActive(true);
                    // Disable gun fire effect after 0.1 seconds
                    Invoke("setGunFireActiveToFalse", 0.1f);
                    // Play shooting animation
                    anim.SetBool("isShooting", true);
                    // Disable shooting animation after 0.1 seconds
                    Invoke("setIsShootingToFalse", 0.1f);
                }
            }
        }
        // If rapid fire is active
        else if (isRapidFireActive)
        {
            // Start rapid fire coroutine for 5 seconds
            StartCoroutine(RapidFire(5f));
            // Check if left mouse button is pressed
            if (Input.GetMouseButton(0))
            {
                // Shoot a bullet rapidly
                rapidShootBullet();
            }
        }

        // Check if right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            // Check if there are grenades left
            if (currentAmountOfGrenade > 0)
            {
                // Throw a grenade
                Instantiate(grenade, transform.position, Quaternion.identity);
                // Reduce the number of grenades left
                currentAmountOfGrenade--;
                // Update the grenade count text
                updateGrenadeText();
            }
        }
    }

    // This method shoots a single bullet
    public void shootBullet()
    {
        // Decrement the number of bullets left
        currentAmountOfBullet -= 1;

        // Update the bullet count display
        updateBulletText();

        // Instantiate a bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);

        //Play the shooting sound
        audioSource.PlayOneShot(shootSound);

        // Add force to the bullet to make it move
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.up * bulletSpeed, ForceMode2D.Impulse);

        // Increment the number of bullets shot
        bulletsShot++;

        // Output the number of bullets shot to the console for debugging purposes
        Debug.Log("Bullets shot: " + bulletsShot);

        // Destroy the bullet after a short delay
        Destroy(bullet, 0.3f);
    }

    // This method shoots a bullet rapidly
    public void rapidShootBullet()
    {
        // Check if enough time has passed since the last bullet was fired
        if (Time.time - lastFireTime > fireRate)
        {
            // Instantiate a bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);

            // Play shooting sound
            audioSource.PlayOneShot(shootSound);

            // Add force to the bullet to make it move
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.up * bulletSpeed, ForceMode2D.Impulse);

            // Destroy the bullet after a short delay
            Destroy(bullet, 0.3f);

            // Record the time that the bullet was fired
            lastFireTime = Time.time;
        }
    }


    // This method hides the gun fire animation
    public void setGunFireActiveToFalse()
    {
        gunFire.SetActive(false);
    }

    // This method resets the shooting animation
    public void setIsShootingToFalse()
    {
        anim.SetBool("isShooting", false);
    }

    IEnumerator RapidFire(float time)
    {
        // Wait for a certain amount of time before stopping rapid fire mode
        yield return new WaitForSeconds(time);

        // Deactivate rapid fire mode and update the UI texts
        isRapidFireActive = false;
        infiniteBulletsText.gameObject.SetActive(false);
        bulletsLeftText.gameObject.SetActive(true);
    }

    public static void updateBulletText()
    {
        // Update the bullets left UI text with the current amount of bullets and the maximum amount of bullets
        bulletsLeftText.text = currentAmountOfBullet.ToString() + " / " + maxBullets.ToString();
    }

    public static void updateGrenadeText()
    {
        // Update the grenade left UI text with the current amount of grenades
        grenadeLeftText.text = "x " + currentAmountOfGrenade.ToString();
    }
}