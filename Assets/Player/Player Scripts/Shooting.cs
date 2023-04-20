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

    public static int maxBulllets = 100;
    public static int currentAmountOfBullet;
    public Text bulletsLeftText;
    public static int bulletsShot;

    public static int maxGrenades = 3;
    public static int currentAmountOfGrenade;
    public Text grenadeLeftText;



    void Start()
    {
        currentAmountOfBullet = maxBulllets;

        bulletsLeftText.text = currentAmountOfBullet.ToString() + " / " + maxBulllets.ToString();

        currentAmountOfGrenade = maxGrenades;

        grenadeLeftText.text = "x " + currentAmountOfGrenade.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        bulletsLeftText.text = currentAmountOfBullet.ToString() + " / " + maxBulllets.ToString();
        grenadeLeftText.text = "x " + currentAmountOfGrenade.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmountOfBullet > 0)
            {
                shootBullet();
                gunFire.SetActive(true);
                Invoke("setGunFireSctiveToFalse", 0.1f);
                anim.SetBool("isShooting", true);
                Invoke("setIsShootingToFalse", 0.1f);
                
            }
        }


        /*else if(Input.GetMouseButton(0))
        {
            GameObject bullet = Instantiate(bulletPrefab,firePoint.transform.position,firePoint.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
            Destroy(bullet, 0.3f);

        }*/

        if (Input.GetMouseButtonDown(1))
        {
            if (currentAmountOfGrenade > 0)
            {
                Instantiate(grenade,transform.position, Quaternion.identity);
                currentAmountOfGrenade--;
                grenadeLeftText.text = "x " + currentAmountOfGrenade.ToString();
            }
            
        }
    }

    public void shootBullet()
    {
        currentAmountOfBullet -= 1;
        bulletsLeftText.text = currentAmountOfBullet.ToString() + " / " + maxBulllets.ToString();

        GameObject bullet = Instantiate(bulletPrefab,firePoint.transform.position,firePoint.transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
        bulletsShot++;
        Debug.Log("Bullets shot: " + bulletsShot);
        Destroy(bullet, 0.3f);
    }

    public void setGunFireSctiveToFalse()
    {
        gunFire.SetActive(false);
    }

    public void setIsShootingToFalse()
    {
        anim.SetBool("isShooting", false);
    }
}
