using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private SFXManager sfxManager;
    [SerializeField]
    private MusicManager musicManager;
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private LevelController levelControl;
    [SerializeField]
    private Text winLosetext, scoreText;

  void Awake()
    {
        musicManager.gameObject.SetActive(false);
        if (levelControl.GetGameState() == LevelController.gameState.Win) //if the player has entered the hole, play success sound
        {
            winLosetext.text = "You won!";
            sfxManager.PlayGameWinAudio();
        }
        else if (levelControl.GetGameState() == LevelController.gameState.Lose) //if the player has run out of fuel, play the game over audio
        {
            winLosetext.text = "You ran out of fuel!";
            sfxManager.PlayGameLossAudio();

        }
        scoreText.text = scoreManager.GetScore().ToString();
    }


  public void OnHomeButtonClicked()
    {
        SceneManager.LoadScene(0); //load the home scene
    }

    public void OnRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reload the current scene
    }

    public void OnMissionsButtonClicked() 
    {
        SceneManager.LoadScene(1); //load the mission scene
    }
}
