// This script enables zooming in and out of the camera and toggles the visibility of UI sprites and canvas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public Camera cam; // Reference to the camera component
    public GameObject UISprites; // Reference to the UI sprites game object
    public Canvas UICanvas; // Reference to the UI canvas component

    // Update is called once per frame
    void Update()
    {
        // Check if the 'A' or 'D' keys are pressed
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            // Set the orthographic size of the camera to 15
            cam.orthographicSize = 15f;

            // Disable the UI canvas and set the visibility of UI sprites to false
            UICanvas.enabled = false;
            UISprites.SetActive(false);
        }
        else
        {
            // Set the orthographic size of the camera to 7
            cam.orthographicSize = 7f;

            // Enable the UI canvas and set the visibility of UI sprites to true
            UICanvas.enabled = true;
            UISprites.SetActive(true);
        }
    }

}
