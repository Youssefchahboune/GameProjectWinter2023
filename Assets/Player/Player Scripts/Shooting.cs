using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Rendering.Universal;

public class Shooting : MonoBehaviour
{
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public GameObject gunFire;
    public Animator anim;
    public GameObject grenade;

    public static int maxBullets = 100;
    public static int currentAmountOfBullet;
    public static Text bulletsLeftText;
    public static int bulletsShot;
    public static Text infiniteBulletsText;

    public static int maxGrenades = 3;
    public static int currentAmountOfGrenade;
    public static Text grenadeLeftText;

    public static bool isRapidFireActive = false;
    private float lastFireTime = 0f;
    private float fireRate = 0.1f;

    void Start()
    {
        bulletsLeftText = GameObject.Find("BulletsLeft").GetComponent<Text>();

        grenadeLeftText = GameObject.Find("Grenades").GetComponent<Text>();

        infiniteBulletsText = GameObject.Find("InfiniteBullets").GetComponent<Text>();

        infiniteBulletsText.gameObject.SetActive(false);

        currentAmountOfBullet = maxBullets;

        updateBulletText();

        currentAmountOfGrenade = maxGrenades;

        updateGrenadeText();

    }

    // Update is called once per frame
    void Update()
    {

        if (!isRapidFireActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentAmountOfBullet > 0)
                {
                    shootBullet();
                    gunFire.SetActive(true);
                    Invoke("setGunFireActiveToFalse", 0.1f);
                    anim.SetBool("isShooting", true);
                    Invoke("setIsShootingToFalse", 0.1f);

                }
            }
        }
        else if (isRapidFireActive)
        {
            StartCoroutine(RapidFire(5f));
            if (Input.GetMouseButton(0))
            {
                rapidShootBullet();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (currentAmountOfGrenade > 0)
            {
                Instantiate(grenade,transform.position, Quaternion.identity);
                currentAmountOfGrenade--;
                updateGrenadeText();
            }
        }
    }

    public void shootBullet()
    {
        currentAmountOfBullet -= 1;
        updateBulletText();

        GameObject bullet = Instantiate(bulletPrefab,firePoint.transform.position,firePoint.transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
        bulletsShot++;
        Debug.Log("Bullets shot: " + bulletsShot);
        Destroy(bullet, 0.3f);
    }

    public void rapidShootBullet()
    {
        if (Time.time - lastFireTime > fireRate)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
            Destroy(bullet, 0.3f);
            lastFireTime = Time.time;
        }
    }


    public void setGunFireActiveToFalse()
    {
        gunFire.SetActive(false);
    }

    public void setIsShootingToFalse()
    {
        anim.SetBool("isShooting", false);
    }

    IEnumerator RapidFire(float time)
    {
        yield return new WaitForSeconds(time);
        isRapidFireActive = false;
        infiniteBulletsText.gameObject.SetActive(false);
        bulletsLeftText.gameObject.SetActive(true);
    }

    public static void updateBulletText()
    {
        bulletsLeftText.text = currentAmountOfBullet.ToString() + " / " + maxBullets.ToString();
    }

    public static void updateGrenadeText()
    {
        grenadeLeftText.text = "x " + currentAmountOfGrenade.ToString();
    }
}
