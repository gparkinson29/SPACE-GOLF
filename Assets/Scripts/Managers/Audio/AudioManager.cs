using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        if (Time.timeScale == 1)
        {
            //muteAllAudio?.Invoke();
            EventManager.Instance.ResumeAudioPlayback();
        }
    }


    /*void StopPlayback()
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
        foreach (AudioSource s in allSFX)
        {
            s.UnPause();
        }
    }*/
       
}
