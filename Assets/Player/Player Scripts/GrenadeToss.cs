using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeToss : MonoBehaviour
{
    private Vector3 targetPos;  // The position to move towards
    public float speed = 10f;  // The speed at which the grenade moves
    public GameObject explosion;  // The explosion object to instantiate when the grenade detonates

    
    private void Start()
    {
        targetPos = GameObject.Find("Dir").transform.position;  // Get the position of the target
        
    }

    private void Update()
    {
        if (speed > 0)  // If the grenade is still moving
        {
            speed -= Random.Range(.05f, .1f);  // Decrement the speed with a random value
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);  // Move towards the target position
        }
        else if (speed < 0)  // If the speed has reached 0
        {
            speed = 0;  // Set the speed to 0

            StartCoroutine(Explode(1));  // Start the explosion coroutine after a delay
        }
    }

    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time);  // Wait for the specified time
        Destroy(gameObject);  // Destroy the grenade object
        Instantiate(explosion, transform.position, Quaternion.identity);  // Instantiate the explosion object at the grenade position
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie") || collision.gameObject.CompareTag("BigZombie"))  // If the grenade collides with a zombie
        {
            StartCoroutine(Explode(0));  // Start the explosion coroutine immediately
        }
    }
}
