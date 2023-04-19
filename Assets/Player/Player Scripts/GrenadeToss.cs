using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeToss : MonoBehaviour
{
    public float grenadeSpeed=50f;
    public GameObject grenadePrefab;
    public GameObject firePoint;
    public static int maxGrenades = 3;
    public static int currentAmountOfGrenades;
    public Text grenadesLeftText;
    // Start is called before the first frame update

     void Start()
    {
        currentAmountOfGrenades = maxGrenades;
        grenadesLeftText.text =  "X " + currentAmountOfGrenades.ToString();
    }
    void Update()
    {
        grenadesLeftText.text = "X " + currentAmountOfGrenades.ToString();
        if (Input.GetMouseButtonDown(1))
        {
            if (currentAmountOfGrenades > 0)
            {
                ThrowGrenade();
            }
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, firePoint.transform.position, firePoint.transform.rotation);
        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();

        // Add force to the grenade to throw it forward
        rb.AddForce(firePoint.transform.up * grenadeSpeed, ForceMode2D.Impulse);
        currentAmountOfGrenades--;
    }
}
