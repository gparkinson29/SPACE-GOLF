using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField]
    private LevelController levelController;

    public void LaunchPause()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
        if (this.gameObject.activeSelf)
        {
            levelController.SetGameState(LevelController.gameState.Pause);
        }
        else
        {
            levelController.SetGameState(LevelController.gameState.putting);
        }
    }

    public void OnHomeClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
