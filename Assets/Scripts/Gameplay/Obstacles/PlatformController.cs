using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] bool playerActivated;
    [Tooltip("0 is Ocillating, 1 is looping, and 2 is for one way")]
    [SerializeField] int settupPath;
    [SerializeField] float speed = 0.05f;
    private bool initialized = false;
    //Check if ambient or in need of player presence
    private bool needPlayer = false;
    private bool touchingPlayer = false;
    //hold an array of checkpoints for the platform to move to
    public List<Transform> checkpoints = new List<Transform>();
    private int targetIndex = 0;
    //toggle between ocillate, loop, or one way
    private enum pathSetting
    {
        ocillate,//0
        loop,//1
        oneWay//2
    }
    pathSetting mySetting = pathSetting.ocillate;


    void Awake()
    {
        InitPlatform(settupPath, playerActivated);
    }

    // Update is called once per frame
    void Update()
    {
        if (initialized)
        {
            if (needPlayer)
            {
                if (touchingPlayer)
                {
                    PlatformMover();
                }
            }
            else
            {
                PlatformMover();
            }
        }
    }
    private int ocillateVar = 1;
    private void PlatformMover()
    {
        if (MoveTowardsTarget(targetIndex))
        {
            switch (mySetting)
            {
                case pathSetting.ocillate: // 0
                    targetIndex += ocillateVar;
                    if (targetIndex == checkpoints.Count - 1 || targetIndex == 0)
                    {
                        ocillateVar = ocillateVar * -1;
                    }
                    break;
                case pathSetting.loop: // 1
                    targetIndex++;
                    if (targetIndex > checkpoints.Count - 1)
                    {
                        targetIndex = 0;
                    }
                    break;
                case pathSetting.oneWay: // 2
                    if (targetIndex == checkpoints.Count - 1)
                    {
                        initialized = false;
                    }
                    else
                    {
                        targetIndex++;
                    }
                    break;
            }
        }
    }

    private bool MoveTowardsTarget(int i)
    {
        transform.position = Vector3.MoveTowards(transform.position, checkpoints.ElementAt<Transform>(i).position, 1f * Time.deltaTime * speed);
        return transform.position == checkpoints.ElementAt<Transform>(i).position;
    }

    private void InitPlatform(int pathSetting, bool needplayer)
    {
        mySetting = (pathSetting)pathSetting;
        this.needPlayer = needplayer;
        initialized = true;
    }

    private void OnCollisionStay(Collision c)
    {
        if (c.gameObject.tag == "Player" && GameObject.FindGameObjectWithTag("LVLcontroller").GetComponent<LevelController>().GetGameState() == LevelController.gameState.putting)
        {
            touchingPlayer = true;
        }
    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            //Debug.Log("Trying set parent");
            c.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            //Debug.Log("Removing");
            c.gameObject.transform.SetParent(null);
        }
    }
}
