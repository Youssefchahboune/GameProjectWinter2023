// This script sets the start score of the game and updates the score UI text.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetStartScore : MonoBehaviour
{
    private Text scoreText; // Reference to the UI text that displays the score.
    [SerializeField] public static int score = 500; // The starting score for the game, can be set in the Inspector.
    public static int currentScore; // The current score of the game.

    // Start is called before the first frame update
    void Start()
    {
        // Get the UI text component and set it to display the current score.
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        currentScore = score;
        scoreText.text = currentScore.ToString() + " pts";
    }

    // Update is called once per frame
    void Update()
    {
        // Call the UpdateScoreText() function to update the score UI text every frame.
        UpdateScoreText();
    }

    // Updates the score UI text to display the current score.
    public void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString() + " pts";
    }
}
