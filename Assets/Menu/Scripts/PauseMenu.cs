using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    Canvas mainMenu, optionsMenu;
    [SerializeField]
    Slider volumeSlider;
    [SerializeField]
    Toggle mute;
    public AudioSource audioSource;
    public AudioListener audioListener;

    void Start()
    {
        mainMenu.enabled = false;
        optionsMenu.enabled = false;
        audioSource = Camera.main.GetComponent<AudioSource>();
        audioListener = Camera.main.GetComponent<AudioListener>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenu.enabled == true)
            {
                mainMenu.enabled = true;
                optionsMenu.enabled = false;
            }
            else if (mainMenu.enabled == true)
            {
                mainMenu.enabled = false;
                optionsMenu.enabled = false;
                audioSource.Stop();
            }
            else
            {
                mainMenu.enabled = true;
                optionsMenu.enabled = false;
                audioSource.Play();
            }

        }
    }
    public void ChangeVolume()
    {
        if (mute.isOn)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = volumeSlider.value;
        }
    }

    public void MM_MainMenu()
    {
        mainMenu.enabled = true;
        optionsMenu.enabled = false;
    }
    public void mm_Options()
    {
        mainMenu.enabled = false;
        optionsMenu.enabled = true;
    }
    public void MM_Resume()
    {
        mainMenu.enabled = false;
        optionsMenu.enabled = false;
        audioSource.Stop();
    }
    public void MM_Quit()
    {
        Application.Quit();
    }


}
