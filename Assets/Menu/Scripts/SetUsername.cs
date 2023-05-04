using UnityEngine;
using UnityEngine.UI;

public class SetUsername : MonoBehaviour
{
    public Text displayText;

    void Start()
    {
        displayText = FindObjectOfType<Text>();

        string userInput = PlayerPrefs.GetString("UserInput");
        displayText.text = userInput;
    }
}