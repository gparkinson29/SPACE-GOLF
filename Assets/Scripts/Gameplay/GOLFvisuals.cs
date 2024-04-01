using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOLFvisuals : MonoBehaviour
{
    public GameObject player;
    public float smoothness = 1f;
    public LevelController lvlController;

    private void Awake()
    {
        lvlController = GameObject.FindGameObjectWithTag("LVLcontroller").GetComponent<LevelController>();
    }

    private void Update()
    {
        transform.position = player.transform.position;
        Vector3 vel = player.GetComponent<Rigidbody>().velocity;
        if (lvlController.GetGameState() != LevelController.gameState.putting)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(-vel, Vector3.down), smoothness); //Quaternion.LookRotation(-vel, Vector3.down);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(180,player.transform.localEulerAngles.y,0);
        }
        //this.transform.localRotation = Quaternion.Euler(180,,0);
    }
}
