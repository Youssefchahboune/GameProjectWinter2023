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

    private const string MusicMuteKey = "MusicMute";
    private const string SoundFXMuteKey = "SoundFXMute";

    private bool musicIsOn;
    private bool soundFXIsOn;

    private void Awake()
    {
        musicIsOn = false;
        soundFXIsOn = false;
    }

    private void Start()
    {
        // Retrieve the mute state from PlayerPrefs and set the toggle accordingly
        bool isMusicMuted = PlayerPrefs.GetInt(MusicMuteKey, 0) == 1;
        bool isSoundFXMuted = PlayerPrefs.GetInt(SoundFXMuteKey, 0) == 1;
        musicMute.isOn = isMusicMuted;
        soundFXMute.isOn = isSoundFXMuted;

        // Update the mixer volume based on the mute state
        UpdateMixerVolume();
    }

    public void UpdateMixerVolume()
    {
        float musicVolumeValue = musicIsOn ? -80f : Mathf.Log10(musicVolume) * 20;
        musicMixerGroup.audioMixer.SetFloat("Music Volume", musicVolumeValue);

        float soundFXVolumeValue = soundFXIsOn ? -80f : Mathf.Log10(soundFXVolume) * 20;
        soundFXMixerGroup.audioMixer.SetFloat("Sound FX Volume", soundFXVolumeValue);
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
        musicIsOn = !musicIsOn;
        PlayerPrefs.SetInt(MusicMuteKey, musicIsOn ? 1 : 0);
        UpdateMixerVolume();
    }

    public void onSoundFXToggleValueChange()
    {
        soundFXIsOn = !soundFXIsOn;
        PlayerPrefs.SetInt(SoundFXMuteKey, soundFXIsOn ? 1 : 0);
        UpdateMixerVolume();
    }
}
