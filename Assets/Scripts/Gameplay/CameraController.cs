using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Getting Level Controller
    private LevelController lvlController; //This is our LevelController


    private Camera cam;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lvlController = GameObject.FindGameObjectWithTag("LVLcontroller").GetComponent<LevelController>();
    }

    private void Update()
    {
        if (lvlController.GetGameState() == LevelController.gameState.putting)
        {
            transform.position = player.transform.position;
        }
    }
}
