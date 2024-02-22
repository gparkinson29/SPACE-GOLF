using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public enum gameState
    {
        putting,//player not moving, able to drag and fire player
        ARputting, //for AR mode
        exploring,//look around map
        ARexploring, //for AR mode
        shooting,//player moving
        ARshooting, //for AR mode
        Win, //End State (Player stops in hole)
        Lose, //End State (Player Reaches 12 strokes) (may not be necessary
        Pause //pause game
    }
    private gameState _state; //current state
    private int currentLevel;
    private bool hasUpdatedCurrentLevel;
    [SerializeField]
    private GameObject gameOverCanvas;


    private void Awake()
    {
        _state = 0;
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        hasUpdatedCurrentLevel = false;
    }
    private void Update()
    {
        //This script should only control things that effect the entire gameplay, not just the ball or camera
        //
        if (_state == gameState.Pause || _state == gameState.Win || _state == gameState.Lose)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        switch (_state)
        {
            case gameState.putting:
                break;
            case gameState.exploring:
                break;
            case gameState.shooting:
                break;
            case gameState.Win: 
                if (!hasUpdatedCurrentLevel)
                {
                    SetLevel();
                    hasUpdatedCurrentLevel=true;
                    EventManager.Instance.PauseAudioPlayback();
                    gameOverCanvas.SetActive(true);
                }
                break;
            case gameState.Lose:
           
                EventManager.Instance.PauseAudioPlayback();
                gameOverCanvas.SetActive(true);
                break;
            case gameState.Pause: 
                EventManager.Instance.PauseAudioPlayback();
                break;
            default:
                Debug.Log("Invalid State");
                break;
        }
    }

    public void SetGameState(gameState state)
    {
        _state = state;
    }
    public gameState GetGameState()
    {
        return _state;
    }

    public void SetLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        PlayerPrefs.Save();
    }
}
