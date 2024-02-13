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

    private void Awake()
    {
        _state = 0;
    }
    private void Update()
    {
        //This script should only control things that effect the entire gameplay, not just the ball or camera
        //
        if (_state != gameState.Pause)
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
                break;
            case gameState.Lose:
                break;
            case gameState.Pause: 
                Time.timeScale = 0;
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
}
