using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider SoundSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    public AudioClip[] musicClips;
    public AudioClip[] sfxClips;
        

    // Update is called once per frame
    void Update()
    {
        if (!musicAudioSource.isPlaying)
        {
            musicAudioSource.PlayOneShot(musicClips[0]);
        }

        PlaySound();
        PlayMusic();
        PlaySFX();
    }

    void PlaySound()
    {
        AudioListener.volume = SoundSlider.value;
    }

    void PlayMusic()
    {
        musicAudioSource.volume = musicSlider.value;

    }

    void PlaySFX()
    {
        sfxAudioSource.volume = sfxSlider.value;
    }
}
