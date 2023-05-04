using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    Canvas pauseMenuCanvas, quitMenuCanvas, gameOverCanvas, optionsMenuCanvas;
    [SerializeField]
    Slider volumeSlider;
    [SerializeField]
    Toggle mute;
    public AudioSource audioSource;
    public AudioListener audioListener;

    void Start()
    {
        pauseMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        optionsMenuCanvas.enabled = false;
        audioSource = Camera.main.GetComponent<AudioSource>();
        audioListener = Camera.main.GetComponent<AudioListener>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (quitMenuCanvas.enabled == true)
            {
                quitMenuCanvas.enabled = false;
                pauseMenuCanvas.enabled = true;
            }
            else if (pauseMenuCanvas.enabled == true)
            {
                pauseMenuCanvas.enabled = false;
                optionsMenuCanvas.enabled = false;
                audioSource.Stop();
            }
            else
            {
                pauseMenuCanvas.enabled = true;
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
        SceneManager.LoadScene("MainMenu");
    }

    public void mm_Options()
    {
        pauseMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = true;
    }

    public void MM_Resume()
    {
        pauseMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = false;
        audioSource.Stop();
    }

    public void MM_Quit()
    {
        pauseMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = true;
    }

    public void QuitGame()
    {
        if (quitMenuCanvas.enabled == true)
        {
            gameOverCanvas.enabled = true;
            StartCoroutine(LoadMainMenu());
        }
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("MainMenu");
    }

    public void CancelQuit()
    {
        pauseMenuCanvas.enabled = true;
        quitMenuCanvas.enabled = false;
    }
}