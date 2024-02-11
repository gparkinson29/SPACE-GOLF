using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioClip[] musicTrackList;
    [SerializeField]
    private AudioClip lastPlayedTrack, currentTrack;

    // Start is called before the first frame update
    void Start()
    {
        currentTrack = musicTrackList[Random.Range(0, musicTrackList.Length)];
        musicSource.clip = currentTrack;
        musicSource.Play();
        //lastPlayedTrack = currentTrack;
    }

    void Update()
    {
        if (!musicSource.isPlaying && Time.timeScale!=0)
        {
            lastPlayedTrack = currentTrack;
            PlayMusic();
            
        }
    }

    void PlayMusic()
    {
        currentTrack = musicTrackList[Random.Range(0, musicTrackList.Length)];
        while (currentTrack == lastPlayedTrack)
        {
            currentTrack = musicTrackList[Random.Range(0, musicTrackList.Length)];
        }
        musicSource.clip = currentTrack;
        musicSource.Play();
    }

    public AudioSource GetMusicSource()
    {
        return musicSource;
    }
}
