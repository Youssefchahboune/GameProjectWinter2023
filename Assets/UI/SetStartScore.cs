using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetStartScore : MonoBehaviour
{
    // Start is called before the first frame update
    private Text scoreText;
    [SerializeField]
    public static int score = 500;
    public static int currentScore;

    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();;
        
        currentScore = score;

        scoreText.text = currentScore.ToString() + " pts";

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString() + " pts";
    }
}
