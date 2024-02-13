using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private MusicManager musicManager;
    [SerializeField]
    private SFXManager SFXManager;
    [SerializeField]
    private StateAudio stateManager;
    private AudioSource[] allSFX;

    void Awake()
    {
        allSFX = SFXManager.GetSFXAudio();
        foreach (AudioSource source in allSFX)
        {
            source.volume = PlayerPrefs.GetFloat("SFX_Volume");
        }
        stateManager.GetStateAudio().volume = PlayerPrefs.GetFloat("SFX_Volume");
        musicManager.GetMusicSource().volume = PlayerPrefs.GetFloat("Music_Volume");
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            StopPlayback();
        }
        else
        {
            ResumePlayback();
        }
    }


    void StopPlayback()
    {
        musicManager.GetMusicSource().Pause();
        foreach (AudioSource s in allSFX)
        {
            s.Pause();
        }

    }

    void ResumePlayback()
    {
        musicManager.GetMusicSource().UnPause();
    }

    void SFXPlayback(bool shouldPlay)
    {
        foreach (AudioSource s in allSFX)
        {
            s.UnPause();
        }
    }

       
}
