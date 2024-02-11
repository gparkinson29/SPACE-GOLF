using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] SFXSource;
    [SerializeField]
    private AudioSource movementSource, portalSource, platformSource, powerDownSource, laserSource, buttonSource, endAudio;
    [SerializeField]
    private AudioClip[] thrusterSounds, powerDownSounds;
    [SerializeField]
    private AudioClip winAudio, lossAudio;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlayPlatformAudio()
    {
        platformSource.Play();
    }

    public void PlayPortalAudio()
    {
        portalSource.Play();
    }

    public void PlayThrusterAudio()
    {
        movementSource.clip = thrusterSounds[Random.Range(0, thrusterSounds.Length)];
        movementSource.Play();
    }

    public void PlayPowerDownAudio()
    {
        powerDownSource.clip = powerDownSounds[Random.Range(0, powerDownSounds.Length)];
        powerDownSource.Play();
    }

    public void PlayLaserCollisionAudio()
    {
        laserSource.Play();
    }

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


    public AudioSource[] GetSFXAudio()
    {
        return SFXSource;
    }
}