using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Getting Level Controller
    private LevelController lvlController; //This is our LevelController

    //Movement Vars
    private bool mouseDown = false;
    private Vector3 mouseStartPos;
    private Rigidbody rb;

    //Camera Vars
    private Camera overlayCam;
    private Camera activeCam;//for later use, switching between the overlay camera and the main camera for raycasting

    //Debug Vars
    public Vector3 powerOutput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        overlayCam = GameObject.FindGameObjectWithTag("OverCam").GetComponent<Camera>();
        lvlController = GameObject.FindGameObjectWithTag("LVLcontroller").GetComponent<LevelController>();
    }

    private void Update()
    {
        if (lvlController.GetGameState() == LevelController.gameState.putting)//for later when the game state script is more implemented
        {
            PuttingState();
        }
    }

    //steps to movement:
    //mouse down save screen pos, mouse up calculate 
    private void PuttingState()
    {
        if (checkMouse())
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseDown = true;
                mouseStartPos = Input.mousePosition;
            }
        }

        if (mouseDown)
        {
            if (Input.GetMouseButtonUp(0))
            {
                mouseDown = false;
                PuttPlayer(mouseStartPos - Input.mousePosition, Vector3.Distance(mouseStartPos, Input.mousePosition)/10);
            }
        }
    }

    private bool checkMouse()//checks if the mouse is over the player
    {
        string[] layermask = new string[1] { "User" };//set up layers for the raycast to target
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask(layermask)))
        {
            Debug.Log(hit.transform.name);
            return hit.transform.gameObject.Equals(gameObject);
        }
        return false;
    }

    private void PuttPlayer(Vector3 direction, float power)
    {
        direction = Vector3.Normalize(direction);

        direction.z = direction.y;
        direction.y = 0;
        Debug.Log(direction);

        powerOutput = power * direction;
        rb.AddForce(direction * power, ForceMode.Impulse);
    }



    ///Code to Rotate player based on button input
    /*
    
            if (isRotating)
        {
            if (rotateLeft)
            {
                this.transform.Rotate(0f, -0.5f, 0f);
            }
            else if (rotateRight)
            {
                this.transform.Rotate(0f, 0.5f, 0f);
            }
        }
    
    public void RotateLeft()
    {
        rotateLeft = true;
        rotateRight = false;
    }

    public void RotateRight()
    {
        rotateRight = true;
        rotateLeft = false;
    }

    public void Rotation(bool shouldRotate)
    {
        isRotating = shouldRotate;
    }
    */


    ///Code to pinch and zoom in and out
    /*
     if (Input.touchCount == 2)
            {
                pinchTouchOne = Input.GetTouch(0);
                pinchTouchTwo = Input.GetTouch(1);
                previousFingerDistance = ((pinchTouchOne.position - pinchTouchOne.deltaPosition) - (pinchTouchTwo.position - pinchTouchTwo.deltaPosition)).magnitude;
                currentFingerDistance = Vector2.Distance(pinchTouchOne.position, pinchTouchTwo.position);
                zoomDistance = Vector2.Distance(pinchTouchOne.deltaPosition, pinchTouchTwo.deltaPosition) * 0.01f;
                if (previousFingerDistance > currentFingerDistance)
                {
                    Camera.main.fieldOfView += zoomDistance;
                }
                else if (previousFingerDistance < currentFingerDistance)
                {
                    Camera.main.fieldOfView -= zoomDistance;
                }
                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 10f, 80f);
            }
    */
}
