using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource SFXSource;
    // Start is called before the first frame update
    void Start()
    {
        SFXSource.volume = PlayerPrefs.GetFloat("SFX_Volume");
    }
}