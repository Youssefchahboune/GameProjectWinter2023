using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeToss : MonoBehaviour
{
    public float grenadeSpeed=5f;
    public GameObject grenadePrefab;
    public GameObject firePoint;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, firePoint.transform.position, firePoint.transform.rotation);
        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();

        // Add force to the grenade to throw it forward
        rb.AddForce(firePoint.transform.up * grenadeSpeed, ForceMode2D.Impulse);
    }
}
