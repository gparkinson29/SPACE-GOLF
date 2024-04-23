using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentController : MonoBehaviour
{
    /* Steps;
     * 1 - Get Target Exit Vent
     * 2 - On Ball Hit save and send velocity
     * 3 - teleport ball and maintain velocity
     */

    [SerializeField] public VentController targetVent;
    public float offset = 5f;
    public float exitPow = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Rigidbody playerRb = player.GetComponent<Rigidbody>();
            //do the teleport
            player.transform.position = targetVent.GetExitPoint();
            playerRb.rotation  = targetVent.transform.rotation;
            playerRb.AddForce(-exitPow * targetVent.transform.forward, ForceMode.Impulse);
        }
    }

    public Vector3 GetExitPoint()
    {
        return gameObject.transform.position - (offset * transform.forward);
    }
}
