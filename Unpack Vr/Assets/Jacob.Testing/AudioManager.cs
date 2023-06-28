using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioDetails[] musicAudio, sfxAudio;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("BackgroundMusic(Test)");
    }

    public void PlayMusic(string name)
    {
        AudioDetails audio = Array.Find(musicAudio, x => x.audioName== name);
        if(audio == null) { Debug.Log("Audio not found"); }
        else
        {
            musicSource.clip = audio.clip;
            musicSource.Play();
        }

    }

    public void PlaySFX(string name)
    {
        AudioDetails audio = Array.Find(sfxAudio, x => x.audioName == name);
        if (audio == null) { Debug.Log("Audio not found"); }
        else
        {
            sfxSource.clip = audio.clip;
            sfxSource.PlayOneShot(audio.clip);
        }

    }

    public void AdjustMasterVolume(float value)
    {
        AudioListener.volume = value;
    }


}
