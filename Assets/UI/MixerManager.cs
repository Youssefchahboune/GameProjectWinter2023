using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerManager : MonoBehaviour
{
    public static float musicVolume { get; private set; }
    public static float soundFXVolume { get; private set; }
    [SerializeField]
    Toggle musicMute;
    [SerializeField]
    Toggle soundFXMute;
    [SerializeField]
    private AudioMixerGroup musicMixerGroup;
    [SerializeField]
    private AudioMixerGroup soundFXMixerGroup;

    private bool musicIsOn;
    private bool soundFXIsOn;

    private void Awake()
    {
        musicIsOn = false;
        soundFXIsOn = false;
    }

    public void onMusicSliderValueChange(float value)
    {
        if (!musicIsOn)
        {
            musicVolume = value;
            musicMixerGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(musicVolume) * 20);
        }

        else
        {
            musicMixerGroup.audioMixer.SetFloat("Music Volume", -80);

        }

    }

    public void onSoundFXSliderValueChange(float value)
    {
        if (!soundFXIsOn)
        {
            soundFXVolume = value;
            soundFXMixerGroup.audioMixer.SetFloat("Sound FX Volume", Mathf.Log10(soundFXVolume) * 20);
        }
        else
        {
            soundFXMixerGroup.audioMixer.SetFloat("Sound FX Volume", -80);

        }

    }

    public void onMusicToggleValueChange()
    {
        if (!musicIsOn)
        {
            musicMixerGroup.audioMixer.SetFloat("Music Volume", -80);
            musicIsOn = true;
        }
        else
        {
            musicMixerGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(musicVolume) * 20);
            musicIsOn = false;
        }
    }

    public void onSoundFXToggleValueChange()
    {
        if (!soundFXIsOn)
        {
            soundFXMixerGroup.audioMixer.SetFloat("Sound FX Volume", -80);
            soundFXIsOn = true;
        }
        else
        {
            soundFXMixerGroup.audioMixer.SetFloat("Sound FX Volume", Mathf.Log10(soundFXVolume) * 20);
            soundFXIsOn = false;
        }
    }
}
