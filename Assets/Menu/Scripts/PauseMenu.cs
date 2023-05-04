using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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

    public TMP_Text statsText;
    public TMP_Text gameOverStatsText;

    public ZombieDies zombieDiesScript;
    public SetStartScore scoreScript;
    public ZombieSpawns zombieSpawnScript;
    public Shooting shootingScript;
    public PlayerInZone shopScript;
    public PlayerMove moveScript;


    void Start()
    {
        pauseMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        optionsMenuCanvas.enabled = false;
        audioSource = Camera.main.GetComponent<AudioSource>();
        audioListener = Camera.main.GetComponent<AudioListener>();

        zombieDiesScript = FindObjectOfType<ZombieDies>();
        scoreScript = FindObjectOfType<SetStartScore>();
        zombieSpawnScript = FindObjectOfType<ZombieSpawns>();
        shootingScript = FindObjectOfType<Shooting>();
        shopScript = FindObjectOfType<PlayerInZone>();
        moveScript = FindObjectOfType<PlayerMove>();

        volumeSlider.value = AudioListener.volume;

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
                lookAtMouseScript.enabled = true;
                shootingScript.enabled = true;
                moveScript.enabled = true;
            }
            else if (optionsMenuCanvas.enabled == true)
            {
                optionsMenuCanvas.enabled = false;
                pauseMenuCanvas.enabled = true;
                Time.timeScale = 0;
            }
            else
            {
                pauseMenuCanvas.enabled = true;
                audioSource.Play();
                Time.timeScale = 0;
                lookAtMouseScript.enabled = false;
                shootingScript.enabled = false;
                moveScript.enabled = false;
            }
        }

        statsText.text = SetStartScore.currentScore.ToString() + "\n"
            + ZombieDies.countOfDeadZombies.ToString() + "\n"
            + ZombieSpawns.countOfZombiesSpawned.ToString() + "\n"
            + Shooting.bulletsShot.ToString() + "\n"
            + PlayerInZone.scoreSpent.ToString();

        gameOverStatsText.text = SetStartScore.currentScore.ToString() + "\n"
            + ZombieDies.countOfDeadZombies.ToString() + "\n"
            + ZombieSpawns.countOfZombiesSpawned.ToString() + "\n"
            + Shooting.bulletsShot.ToString() + "\n"
            + PlayerInZone.scoreSpent.ToString();
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

    public void MM_PauseMenu()
    {
        pauseMenuCanvas.enabled = true;
        optionsMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = false;
        Time.timeScale = 0;
        lookAtMouseScript.enabled = false;
        shootingScript.enabled = false;
        moveScript.enabled = false;

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
        quitMenuCanvas.enabled = false;
        audioSource.Stop();
        Time.timeScale = 1;
        // disable scripts
        lookAtMouseScript.enabled = true;
        shootingScript.enabled = true;
        moveScript.enabled = true;

    }

    public void MM_Quit()
    {
        pauseMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = true;
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        pauseMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = false;
        gameOverCanvas.enabled = true;
    }

    public void CancelQuit()
    {
        pauseMenuCanvas.enabled = true;
        quitMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = false;
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
