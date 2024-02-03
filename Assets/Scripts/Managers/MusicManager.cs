using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.volume = PlayerPrefs.GetFloat("Music_Volume");
    }
}
