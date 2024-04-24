using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject doorR;
    public GameObject doorL;

    public float speed = 20f;
    public float width = 10f;

    Vector3 orignalPosL;
    Vector3 orignalPosR;

    private bool doorOpen = true;

    private void Awake()
    {
        orignalPosL = doorL.transform.position;
        orignalPosR = doorR.transform.position;
        StartCoroutine(DoorLoop());
    }

    public IEnumerator DoorLoop()
    {
        while (true)
        {
            doorOpen = !doorOpen;
            yield return new WaitForSeconds(Random.Range(4f,6f));
        }
    }

    public void Update()
    {
        if (doorOpen)
        {
            doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, orignalPosL - doorL.transform.up* width, Time.deltaTime * speed);
            doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, orignalPosR + doorR.transform.up* width, Time.deltaTime * speed);
        }
        else
        {
            doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, orignalPosL, Time.deltaTime * speed);
            doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, orignalPosR, Time.deltaTime * speed);
        }
    }
}
