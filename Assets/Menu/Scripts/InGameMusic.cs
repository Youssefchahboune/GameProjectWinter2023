using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMusic : MonoBehaviour
{
    [SerializeField]
    Canvas pauseMenuCanvas, quitMenuCanvas, gameOverCanvas, optionsMenuCanvas;

    public AudioSource gameMusic;
    public AudioClip mainMusicClip;
    public AudioClip minigunMusicClip;
    public AudioClip pauseMusicClip;

    private bool isMinigunMusicPlaying = false;
    private bool isPauseMusicPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        gameMusic.clip = mainMusicClip;
        gameMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenuCanvas.enabled || quitMenuCanvas.enabled || gameOverCanvas.enabled || optionsMenuCanvas.enabled)
        {
            if (!isPauseMusicPlaying)
            {
                gameMusic.Pause();
                gameMusic.clip = pauseMusicClip;
                gameMusic.Play();
                isPauseMusicPlaying = true;
            }
        }
        else
        {
            if (isPauseMusicPlaying)
            {
                gameMusic.Stop();
                gameMusic.clip = mainMusicClip;
                gameMusic.Play();
                isPauseMusicPlaying = false;
            }

            if (!gameMusic.isPlaying)
            {
                gameMusic.Stop();
                gameMusic.clip = mainMusicClip;
                gameMusic.Play();
            }

            if (Shooting.isRapidFireActive && !isMinigunMusicPlaying)
            {
                gameMusic.Stop();
                gameMusic.clip = minigunMusicClip;
                gameMusic.Play();
                isMinigunMusicPlaying = true;
            }
            else if (!Shooting.isRapidFireActive && isMinigunMusicPlaying)
            {
                gameMusic.Stop();
                gameMusic.clip = mainMusicClip;
                gameMusic.Play();
                isMinigunMusicPlaying = false;
            }
        }
    }
}
