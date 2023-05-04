using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject startInputCanvas;
    public TMP_Text errorTextObject;

    void Start()
    {
        // Make sure the StartInput canvas is deactivated when the game starts
        startInputCanvas.SetActive(false);
        errorTextObject.gameObject.SetActive(false);
    }

    // Called when the "Start" button is clicked
    public void StartGame()
    {
        // Activate the StartInput canvas when the Start button is clicked
        startInputCanvas.SetActive(true);
    }

    // Called when the "Save" button is clicked in the StartInput canvas
    public void SaveInput()
    {
        string userInput = inputField.text;
        if (string.IsNullOrEmpty(userInput))
        {
            // Activate the error text object if no text is entered
            errorTextObject.gameObject.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetString("UserInput", userInput);
            SceneManager.LoadScene("Game Scene");
        }
    }
}