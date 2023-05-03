using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    // A reference to the player's transform
    private Transform playerTransform;

    // The speed at which the object should move towards the player
    [SerializeField] private float speed;

    private void Start()
    {
        // Find the player's transform using its tag and assign it to the playerTransform variable
        playerTransform = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Transform>();

        // Set the speed to a random value between 2 and 4
        speed = Random.Range(2f, 4f);
    }

    void Update()
    {
        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

        // Rotate towards the player's position
        Vector3 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
