using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    private static Text scoreText;
    public string bulletTag = "Bullet";

    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    private void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(bulletTag))
        {
            SetStartScore.currentScore += 10;
        }
    }
}
