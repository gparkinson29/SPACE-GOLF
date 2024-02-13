using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAudio : MonoBehaviour //the ambient noises unique to each level should be referenced with this script
{
    [SerializeField]
    private AudioSource endAudio;
    [SerializeField]
    private AudioClip winAudio, lossAudio;



    public void PlayGameLossAudio()
    {
        endAudio.clip = lossAudio;
        endAudio.Play();
    }

    public void PlayGameWinAudio()
    {
        endAudio.clip = winAudio;
        endAudio.Play();
    }

    public AudioSource GetStateAudio()
    {
        return endAudio;
    }
}
