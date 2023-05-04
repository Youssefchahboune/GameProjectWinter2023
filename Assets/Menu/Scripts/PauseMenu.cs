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
    public LookAtMouse lookAtMouseScript;
    public Shooting shootingScript;

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
                Time.timeScale = 0;
            }
            else if (pauseMenuCanvas.enabled == true)
            {
                pauseMenuCanvas.enabled = false;
                optionsMenuCanvas.enabled = false;
                audioSource.Stop();
                Time.timeScale = 1;
                // disable scripts
                lookAtMouseScript.enabled = true;
                shootingScript.enabled = true;
            }
            else
            {
                pauseMenuCanvas.enabled = true;
                audioSource.Play();
                Time.timeScale = 0;
                // enable scripts
                lookAtMouseScript.enabled = false;
                shootingScript.enabled = false;
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
        Time.timeScale = 0;
    }

    public void MM_Resume()
    {
        pauseMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = false;
        audioSource.Stop();
        Time.timeScale = 1;
        // disable scripts
        lookAtMouseScript.enabled = true;
        shootingScript.enabled = true;
    }

    public void MM_Quit()
    {
        pauseMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = true;
        Time.timeScale = 0;
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
        Time.timeScale = 0;
    }
}
