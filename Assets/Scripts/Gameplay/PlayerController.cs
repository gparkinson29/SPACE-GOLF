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
    public float speed = 100.0f;

    //Touch Vars
    private Touch touch;
    private bool waiting = false;
    private Vector3 startpos = Vector3.zero;

    //Camera Vars
    private Camera overlayCam;
    private Camera activeCam;//for later use, switching between the overlay camera and the main camera for raycasting

    //Debug Vars
    public bool debug = true;
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
        }else if (lvlController.GetGameState() == LevelController.gameState.shooting)
        {
            
        }
    }
    private void FixedUpdate()
    {

    }

    //steps to movement:
    //mouse down save screen pos, mouse up calculate 
    private void PuttingState()
    {
        if (debug)
        {
            MouseDragShoot();
        }
        else
        {
            DragShoot();
        }
    }

    private void MouseDragShoot()
    {
        if (CheckMouse())
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
                PuttPlayer(mouseStartPos - Input.mousePosition, Vector3.Distance(mouseStartPos, Input.mousePosition) / 10);
            }
        }
    }

    private bool CheckMouse()//checks if the mouse is over the player
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
    private bool CheckTouch(int i)
    {
        touch = Input.GetTouch(i);
        string[] layermask = new string[1] { "User" };//set up layers for the raycast to target
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask(layermask)) && touch.phase == TouchPhase.Began)
        {
            Debug.Log(hit.transform.name);
            return hit.transform.gameObject.Equals(gameObject);
        }
        return false;
    }

    private void DragShoot()
    {
        //Swipe
        //Mobile 2
        Vector3 movement = new Vector3(Input.acceleration.y, 0.0f, Input.acceleration.x);
        //Debug.Log("Mobile device");
        if (Input.touchCount > 0)
        {
            string[] layermask = new string[1] { "User" };
            touch = Input.GetTouch(0);
            RaycastHit currentPos;
            Ray currentRay = Camera.main.ScreenPointToRay(touch.position);
            Physics.Raycast(currentRay, out currentPos);
            if (CheckTouch(0) && !waiting)
            {
                waiting = true;
                startpos = currentPos.point;
                Debug.Log(waiting);
            }
            else if (touch.phase == TouchPhase.Ended && waiting)
            {
                waiting = false;
                Debug.Log(waiting);
                Debug.DrawLine(startpos, currentPos.point, Color.green);
                GetComponent<Rigidbody>().AddForce((startpos - currentPos.point) * speed);
            }
        }
        //GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
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
