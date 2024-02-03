using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    [SerializeField]
    private Button startGameButton;
    [SerializeField]
    private Button settingsButton;
    [SerializeField]
    private Button creditsButton;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Music_Volume"))
        {
            PlayerPrefs.SetFloat("Music_Volume", 1f);
        }
        if (!PlayerPrefs.HasKey("SFX_Volume"))
        {
            PlayerPrefs.SetFloat("SFX_Volume", 1f);
        }
    }

    public void StartGame()
    {
        //for now, loads the mission board; later, could be adjusted to reflect the player's last selected mission
        SceneManager.LoadScene(1);
    }

    public void LoadSettings()
    {
        //for now, loads the tutorial; later, needs to be adjusted to reflect the player's last selected mission
        SceneManager.LoadScene(2);
    }
}
