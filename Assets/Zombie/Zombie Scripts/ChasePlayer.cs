using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private float speed;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Transform>();
        speed = Random.Range(2f, 4f);
    }

    void Update()
    {
        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        Vector3 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
