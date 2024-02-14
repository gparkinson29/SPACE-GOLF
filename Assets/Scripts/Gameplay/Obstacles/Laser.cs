using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private SFXManager sfxManager;
    [SerializeField]
    private float timingInterval;

    void Start()
    {
        InvokeRepeating("ToggleLaser", timingInterval, timingInterval);
    }

    void ToggleLaser()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sfxManager.PlayLaserCollisionAudio();
        }
    }
}
