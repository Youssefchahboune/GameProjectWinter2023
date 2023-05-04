using UnityEngine;
using UnityEngine.UI;

public class SetUsername : MonoBehaviour
{
    public Text displayText;

    void Start()
    {
        string userInput = PlayerPrefs.GetString("UserInput");
        displayText.text = userInput;
    }
}