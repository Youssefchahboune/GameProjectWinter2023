using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    private GameObject scoreObject;
    private static int score = 500;
    public string bulletTag = "Bullet";

    void Start()
    {
        scoreObject = GameObject.Find("Score");
        UpdateScoreText();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(bulletTag))
        {
            score += 10;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        Text scoreText = scoreObject.GetComponent<Text>();
        if (scoreText != null)
        {
            scoreText.text = score + " pts";
        }
    }
}
