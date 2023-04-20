using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    private Text scoreText;
    public static int currentScore;
    public string bulletTag = "Bullet";

    void Start()
    {
        currentScore = SetStartScore.score;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    private void Update()
    {
        UpdateScoreText();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(bulletTag))
        {
            currentScore += 10;
        }
    }

    void UpdateScoreText()
    {
            scoreText.text = currentScore.ToString() + " pts";
    }
    public void AddPoints(int points)
    {
        currentScore += points;
    }

    public void buyWithPoints(int points)
    {
        currentScore -= points;
    }
}
