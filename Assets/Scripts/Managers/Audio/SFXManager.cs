using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] SFXSource;
    [SerializeField]
    private AudioSource portalSource, powerDownSource, laserSource, buttonSource, ambience1, ambience2;
    [SerializeField]
    private AudioClip[] powerDownSounds;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlayPortalAudio()
    {
        portalSource.Play();
        Debug.Log("went through vent");
    }

    public void PlayPowerDownAudio()
    {
        powerDownSource.clip = powerDownSounds[Random.Range(0, powerDownSounds.Length)];
        powerDownSource.Play();
    }

    public void PlayLaserCollisionAudio()
    {
        Debug.Log("laser collision");
        laserSource.Play();
    }

    public AudioSource[] GetSFXAudio()
    {
        return SFXSource;
    }
}