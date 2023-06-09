using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    Canvas pauseMenuCanvas, quitMenuCanvas, gameOverCanvas, optionsMenuCanvas;
    
    [SerializeField]
    private AudioClip menuClickSound;
    
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
    public HitByZombie healthScript;
    public ChasePlayer zombieChaseScript;
    public ChasePlayer bigZombieChaseScript;
    public MedKitUse medkitScript;

    void Start()
    {
        pauseMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        optionsMenuCanvas.enabled = false;
        audioSource = GetComponent<AudioSource>();
        audioListener = Camera.main.GetComponent<AudioListener>();

        zombieDiesScript = FindObjectOfType<ZombieDies>();
        scoreScript = FindObjectOfType<SetStartScore>();
        zombieSpawnScript = FindObjectOfType<ZombieSpawns>();
        shootingScript = FindObjectOfType<Shooting>();
        shopScript = FindObjectOfType<PlayerInZone>();
        moveScript = FindObjectOfType<PlayerMove>();

        SpawnBigZombie.NumberOfBigZombieCurrentlyOnTheMap = 0;
        Shooting.bulletsShot = 0;
        ZombieDies.countOfDeadZombies = 0;
        ZombieSpawns.countOfTotalZombies = 0;
        ZombieSpawns.countOfZombiesSpawned = 0;

        zombieChaseScript.enabled = true;
        bigZombieChaseScript.enabled = true;
        medkitScript.enabled = true;
        healthScript.enabled = true;
    }

    void Update()
    {
        if (gameOverCanvas.enabled == true)
        {
            medkitScript.enabled = false;
            HitByZombie.currentHealth = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayMenuClickSound();
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

    private void PlayMenuClickSound()
    {
        audioSource.PlayOneShot(menuClickSound);
    }

    

    public void MM_PauseMenu()
    {
        PlayMenuClickSound();
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
        PlayMenuClickSound();
        pauseMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = true;
        Time.timeScale = 0;
    }

    public void MM_Resume()
    {
        PlayMenuClickSound();
        pauseMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = false;
        audioSource.Stop();
        Time.timeScale = 1;
        lookAtMouseScript.enabled = true;
        shootingScript.enabled = true;
        moveScript.enabled = true;

    }

    public void MM_Quit()
    {
        PlayMenuClickSound();
        pauseMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = true;
        medkitScript.enabled = false;
        healthScript.enabled = false;
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        PlayMenuClickSound();
        Time.timeScale = 1;
        lookAtMouseScript.enabled = false;
        shootingScript.enabled = false;
        moveScript.enabled = false;
        pauseMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = false;
        quitMenuCanvas.enabled = false;
        gameOverCanvas.enabled = true;
        medkitScript.enabled = false;
        HitByZombie.currentHealth = 0;

    }

    public void CancelQuit()
    {
        PlayMenuClickSound();
        pauseMenuCanvas.enabled = true;
        quitMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = false;
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        PlayMenuClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        SpawnBigZombie.NumberOfBigZombieCurrentlyOnTheMap = 0;
        Shooting.bulletsShot = 0;
        ZombieDies.countOfDeadZombies = 0;
        ZombieSpawns.countOfTotalZombies = 0;
        ZombieSpawns.countOfZombiesSpawned = 0;
        zombieChaseScript.enabled = true;
        bigZombieChaseScript.enabled = true;
        medkitScript.enabled = true;
        healthScript.enabled = true;
    }

    public void MainMenu()
    {
        PlayMenuClickSound();
        SceneManager.LoadScene("MainMenu");

    }
}
