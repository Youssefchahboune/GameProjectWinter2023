using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 3f;

    void Update()
    {
        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

        // Rotate towards the player
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0f; // Keep the zombie upright
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);
    }
}
