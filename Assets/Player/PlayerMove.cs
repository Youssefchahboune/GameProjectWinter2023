using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float playerSpeed;
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the input from the horizontal and vertical axis
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Normalize the input vector to prevent diagonal movement from being faster
        Vector3 inputVector = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // Get the direction vector based on the player's up vector
        Vector3 directionVector = (transform.up * inputVector.y);
            

        // Move the player in the direction vector
        transform.position += directionVector * playerSpeed * Time.deltaTime;

    }
}
