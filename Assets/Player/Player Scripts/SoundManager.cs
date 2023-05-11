using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip maxAmmoSound;
    public AudioClip kaboomSound;
    public AudioClip healthSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Trigger entered: " + other.tag);

        if (other.CompareTag("maxammo"))
        {
            PlaySound(maxAmmoSound);
        }
        else if (other.CompareTag("nuke"))
        {
            PlaySound(kaboomSound);
        }
        else if (other.CompareTag("medkit"))
        {
            PlaySound(healthSound);
        }
        
    

}

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
