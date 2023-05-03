// This script is responsible for smoothly following a target object with the camera
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform target; // The target object that the camera will follow
    public float smoothSpeed = 0.125f; // The speed at which the camera will move towards its target position
    public Vector3 offset; // The offset between the camera's position and the target object's position

    void FixedUpdate()
    {
        // Calculate the desired position of the camera by adding the offset to the target's position
        Vector3 desiredPosition = target.position + offset;

        // Use the Lerp function to smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position to the smoothed position
        transform.position = smoothedPosition;
    }

}
