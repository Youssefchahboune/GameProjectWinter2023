using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public TMP_InputField inputField;

    // Called when the "Save" button is clicked
    public void SaveInput()
    {
        string userInput = inputField.text;
        PlayerPrefs.SetString("UserInput", userInput);
        SceneManager.LoadScene("Game Scene");
    }
}