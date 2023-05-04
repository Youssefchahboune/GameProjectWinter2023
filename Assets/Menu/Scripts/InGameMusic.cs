using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMusic : MonoBehaviour
{
    [SerializeField]
    Canvas pauseMenuCanvas, quitMenuCanvas, gameOverCanvas, optionsMenuCanvas;

    public AudioSource gameMusic;

    // Start is called before the first frame update
    void Awake()
    {
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
        }
        else
        {
            if (!gameMusic.isPlaying)
            {
                gameMusic.Play();
            }
        }
    }
}
