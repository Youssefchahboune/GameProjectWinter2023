using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//using UnityEngine.Rendering.Universal;

public class Shooting : MonoBehaviour
{
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public GameObject gunFire;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootBullet();
            gunFire.SetActive(true);
            Invoke("setGunFireSctiveToFalse",0.1f);
            
        }
        
        
        /*else if(Input.GetMouseButton(1))
        {
            shootBullet();

        }*/
    }

    public void shootBullet()
    {

        GameObject bullet = Instantiate(bulletPrefab,firePoint.transform.position,firePoint.transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
       
        Destroy(bullet, 0.3f);
    }

    public void setGunFireSctiveToFalse()
    {
        gunFire.SetActive(false);
    }
}
