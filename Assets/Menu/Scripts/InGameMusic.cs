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

    private bool isMinigunMusicPlaying = false;

    // Start is called before the first frame update
    void Awake()
    {
        gameMusic.clip = mainMusicClip;
        gameMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenuCanvas.enabled || quitMenuCanvas.enabled || gameOverCanvas.enabled || optionsMenuCanvas.enabled)
        {
            if (gameMusic.isPlaying)
            {
                gameMusic.Pause();
            }
            if (isMinigunMusicPlaying)
            {
                gameMusic.clip = mainMusicClip;
                isMinigunMusicPlaying = false;
            }
        }
        else
        {
            if (!gameMusic.isPlaying)
            {
                gameMusic.Play();
            }

            if (Shooting.isRapidFireActive && !isMinigunMusicPlaying)
            {
                gameMusic.clip = minigunMusicClip;
                gameMusic.Play();
                isMinigunMusicPlaying = true;
            }
            else if (!Shooting.isRapidFireActive && isMinigunMusicPlaying)
            {
                gameMusic.clip = mainMusicClip;
                gameMusic.Play();
                isMinigunMusicPlaying = false;
            }
        }
    }
}
