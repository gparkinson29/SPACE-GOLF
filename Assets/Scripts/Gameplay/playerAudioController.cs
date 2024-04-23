using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAudioController : MonoBehaviour
{
    public AudioClip launchSound;
    public AudioClip stopSound;

    private AudioSource mySource;

    private void Awake()
    {
        mySource = GetComponent<AudioSource>();
    }

    public void PlayLaunch()
    {
        mySource.Stop();
        mySource.clip = launchSound;
        mySource.Play();
    }
    
    public void PlayStop()
    {
        mySource.Stop();
        mySource.clip = stopSound;
        mySource.Play();
    }
}
