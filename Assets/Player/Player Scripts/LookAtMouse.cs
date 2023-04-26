// This script allows the player to look at the position of the mouse cursor on the screen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of rotation in degrees per second

    private Transform playerTransform;

    void Start()
    {
        playerTransform = transform; // get reference to the transform of the object this script is attached to
    }

    void Update()
    {
        lookAtMouse(); // calls the method that rotates the player to face the mouse cursor
    }

    private void lookAtMouse()
    {
        // Calculates the direction of the mouse cursor in world space relative to the player's position
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerTransform.position;

        // Calculates the target angle the player needs to face in order to look at the mouse cursor
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // Calculates the current angle of the player's rotation
        float currentAngle = playerTransform.rotation.eulerAngles.z;

        // Calculates the difference in angle between the current angle and the target angle and clamps the value
        float deltaAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed) - currentAngle;

        // Rotates the player to face the mouse cursor
        playerTransform.rotation = Quaternion.Euler(0f, 0f, currentAngle + deltaAngle);
    }
}
