using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour //the ambient noises unique to each level should be referenced with this script
{
    [SerializeField]
    private AudioSource[] ambienceSources;


    public AudioSource[] GetAmbienceAudio()
    {
        return ambienceSources;
    }
}
