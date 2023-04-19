using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeToss : MonoBehaviour
{

    public float grenadeSpeed = 50f;
    public GameObject grenadePrefab;
    public GameObject firePoint;
    public static int maxGrenades = 3;
    public static int currentAmountOfGrenades;
    public Text grenadesLeftText;
    public float explosionRadius = 5.0f;
    // Start is called before the first frame update

    void Start()
    {
        currentAmountOfGrenades = maxGrenades;
        grenadesLeftText.text = "X " + currentAmountOfGrenades.ToString();
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

        rb.AddForce(firePoint.transform.up * grenadeSpeed, ForceMode2D.Impulse);
        currentAmountOfGrenades--;
        Explode();
        Destroy(grenade, 2f);
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {

            if (collider.CompareTag("Zombie"))
            {
                Destroy(collider.gameObject,2f);
                ZombieDies.countOfDeadZombies++;
            }
        }
    }
}
