using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetStartScore : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject scoreObject;
    [SerializeField]
    private static int score = 500;

    void Start()
    {
        scoreObject = GameObject.Find("Score");
        Text scoreText = scoreObject.GetComponent<Text>();
        scoreText.text = score + " pts";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
