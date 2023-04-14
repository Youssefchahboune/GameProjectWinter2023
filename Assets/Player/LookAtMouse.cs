using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of rotation in degrees per second

    private Transform playerTransform;

    void Start()
    {
        playerTransform = transform;
    }

    void Update()
    {
        lookAtMouse();
    }

    private void lookAtMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerTransform.position;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        float currentAngle = playerTransform.rotation.eulerAngles.z;
        float deltaAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed) - currentAngle;

        playerTransform.rotation = Quaternion.Euler(0f, 0f, currentAngle + deltaAngle);
    }
}
