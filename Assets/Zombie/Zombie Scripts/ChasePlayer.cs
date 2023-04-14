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

        
        ;
    }
}
