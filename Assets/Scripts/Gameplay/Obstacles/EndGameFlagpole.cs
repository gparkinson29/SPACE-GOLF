using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameFlagpole : MonoBehaviour
{
    [SerializeField]
    private LevelController levelController;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelController.SetGameState(LevelController.gameState.Win);
        }
    }
}
