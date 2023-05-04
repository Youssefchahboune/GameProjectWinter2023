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
    public GameObject askTutorialCanvas;
    public TMP_Text errorTextObject;

    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;
    public GameObject tutorial4;
    public GameObject tutorial5;
    public GameObject tutorial6;


    void Start()
    {
        // Make sure the StartInput canvas is deactivated when the game starts
        startInputCanvas.SetActive(false);
        errorTextObject.gameObject.SetActive(false);
        askTutorialCanvas.SetActive(false);

        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
        tutorial5.SetActive(false);
        tutorial6.SetActive(false);


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
            askTutorialCanvas.SetActive(true);

        }
    }


    public void GoToTut1()
    {
        askTutorialCanvas.SetActive(false);
        tutorial2.SetActive(false);
        tutorial1.SetActive(true);
    }

    public void GoToTut2()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(true);
        tutorial3.SetActive(false);
    }

    public void GoToTut3()
    {
        tutorial2.SetActive(false);
        tutorial3.SetActive(true);
        tutorial4.SetActive(false);
    }

    public void GoToTut4()
    {
        tutorial3.SetActive(false);
        tutorial4.SetActive(true);
        tutorial5.SetActive(false);
    }

    public void GoToTut5()
    {
        tutorial4.SetActive(false);
        tutorial5.SetActive(true);
        tutorial6.SetActive(false);
    }

    public void GoToTut6()
    {
        tutorial5.SetActive(false);
        tutorial6.SetActive(true);
    }

    public void loadGame()
    {
        SceneManager.LoadScene("Game Scene");

    }
}