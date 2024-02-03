using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider SFXSlider;
    [SerializeField]
    private Toggle batterySaver;
    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private AudioSource SFX;

    // Start is called before the first frame update
    void Awake()
    {
        musicSlider.onValueChanged.AddListener((t) => OnMusicSliderChange(musicSlider.value));
        SFXSlider.onValueChanged.AddListener((t) => OnSFXSliderChange(SFXSlider.value));
    }

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music_Volume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX_Volume");
    }

    public void OnMusicSliderChange(float newValue)
    {
        musicSlider.value = newValue;
        music.volume = newValue;
        PlayerPrefs.SetFloat("Music_Volume", newValue);
        PlayerPrefs.Save();
    }

    public void OnSFXSliderChange(float newValue)
    {
        SFXSlider.value = newValue;
        SFX.volume = newValue;
        PlayerPrefs.SetFloat("SFX_Volume", newValue);
        PlayerPrefs.Save();
    }

    public void OnBatterySaverChange()
    {

    }


    public void ReturnHome()
    {
        SceneManager.LoadScene(0);
    }

}
