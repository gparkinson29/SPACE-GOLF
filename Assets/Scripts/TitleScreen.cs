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

    public void StartGame()
    {
        //for now, loads the tutorial; later, needs to be adjusted to reflect the player's last selected mission
        SceneManager.LoadScene(1);
    }

    public void LoadSettings()
    {
        //for now, loads the tutorial; later, needs to be adjusted to reflect the player's last selected mission
        SceneManager.LoadScene(2);
    }
}
