using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    // A reference to the score Text object in the scene
    private static Text scoreText;

    // The tag of the bullet GameObject that can trigger score increase
    public string bulletTag = "Bullet";

    void Start()
    {
        // Find the score Text object in the scene
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider's tag matches the bulletTag
        if (collision.gameObject.CompareTag(bulletTag))
        {
            // Increase the current score by 10 when a bullet collides with the object
            SetStartScore.currentScore += 10;
        }
    }
}
