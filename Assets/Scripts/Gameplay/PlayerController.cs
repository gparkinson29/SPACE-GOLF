using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //Getting Level Controller
    private LevelController lvlController; //This is our LevelController

    //Gameplay Vars
    public int power = 10; //number of strokes
    public float powerOfShot; //input from the powerslider
    private Vector3 aimDirect;

    //UI vars
    public PowerUIController powerUIController;
    public Slider powerSlider;
    public RawImage aimIndicator;
    public Button fireingButton;
    public TMP_Text powerFeedback;

    //Movement Vars
    private bool mouseDown = false, isRotating = false, rotateLeft = false, rotateRight = false;
    private Vector3 mouseStartPos;
    private Rigidbody rb;
    public float speed = 100.0f;

    //Touch Vars
    private Touch touch;
    private bool waiting = false;
    private Vector3 startpos = Vector3.zero;
    //pinch zoom
    private float previousFingerDistance;
    private float currentFingerDistance;

    //Camera Vars
    private Camera overlayCam;
    private Camera activeCam;//for later use, switching between the overlay camera and the main camera for raycasting

    //Debug Vars
    public bool debug = true;
    public Vector3 powerOutput;
    public LevelController debugCon;

    //State Machine Vars
    private bool shootingRoutine = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        overlayCam = GameObject.FindGameObjectWithTag("OverCam").GetComponent<Camera>();
        lvlController = GameObject.FindGameObjectWithTag("LVLcontroller").GetComponent<LevelController>();
        powerUIController.InitPower(power);
    }

    private void FixedUpdate()
    {
        //Can only put while still
        powerOutput = rb.velocity;
        debugCon = lvlController;
        //UI based on putting
        powerSlider.enabled = lvlController.GetGameState() == LevelController.gameState.putting;
        fireingButton.enabled = lvlController.GetGameState() == LevelController.gameState.putting;
        aimIndicator.gameObject.SetActive(lvlController.GetGameState() == LevelController.gameState.putting);
        //
        if (lvlController.GetGameState() == LevelController.gameState.putting)//for later when the game state script is more implemented
        {
            rb.drag = 0;
            rb.freezeRotation = true;
            PuttingState();
        }else if (lvlController.GetGameState() == LevelController.gameState.shooting)
        {
            if (!shootingRoutine)
            {
                StartCoroutine(CheckStopRolling());
            }
        }
    }
    private void Update()
    {
        powerUIController.UpdatePower(power);
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
            PowerRep();
            //DragAim(); //uses finger to aim
            powerOfShot = powerSlider.value;
            powerFeedback.text = powerOfShot.ToString();
            //pinch zoom
            CheckRotation();

            //I can't test this on pc, so someone else will have to test this
            if (Input.touchCount == 2)
            {
                Touch pinchTouchOne = Input.GetTouch(0);
                Touch pinchTouchTwo = Input.GetTouch(1);
                previousFingerDistance = ((pinchTouchOne.position - pinchTouchOne.deltaPosition) - (pinchTouchTwo.position - pinchTouchTwo.deltaPosition)).magnitude;
                currentFingerDistance = Vector2.Distance(pinchTouchOne.position, pinchTouchTwo.position);
                float zoomDistance = Vector2.Distance(pinchTouchOne.deltaPosition, pinchTouchTwo.deltaPosition) * 0.01f;
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
    private bool CheckTouch(int i, string[] layermask)
    {
        touch = Input.GetTouch(i);//set up layers for the raycast to target
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask(layermask)) && touch.phase == TouchPhase.Began)
        {
            Debug.Log(hit.transform.name);
            return hit.transform.gameObject.Equals(gameObject);
        }
        return false;
    }
    private bool CheckTouch(int i)
    {
        touch = Input.GetTouch(i);//set up layers for the raycast to target
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100) && touch.phase == TouchPhase.Began)
        {
            Debug.Log(hit.transform.name);
            return hit.transform.gameObject.Equals(gameObject);
        }
            return false;
    }

    IEnumerator CheckStopRolling()
    {
        shootingRoutine = true;
        while (shootingRoutine)
        {
            yield return new WaitForSeconds(0.01f);
            if (rb.velocity.magnitude < 0.3)
            {
                rb.velocity = Vector3.zero;
                transform.rotation = new Quaternion(0,0,0,0);
                rb.Sleep();
                lvlController.SetGameState(LevelController.gameState.putting);
                shootingRoutine = false;
            }
        }
    }

    //Used In Game
    //replaced with button
    private void DragAim()
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
            if (waiting)
            {
                Vector3 force = (startpos - currentPos.point) * speed;
                force.y = 0.0f;
                aimDirect = force.normalized;
            }
            if (touch.phase == TouchPhase.Ended && waiting)
            {
                waiting = false;
                Debug.Log(waiting);
                Debug.DrawLine(startpos, currentPos.point, Color.green);
            }
            else if (CheckTouch(0, layermask) && !waiting)
            {
                waiting = true;
                startpos = currentPos.point;
                //Debug.Log(waiting);
            }
        }
    }

    //UI Feedback for Phone
    private void PowerRep()
    {
        //based on aim direct
        if (false)
        {
            float angle = Vector3.Angle(aimDirect, Vector3.forward);
            Debug.Log(aimDirect.x);

            if (aimDirect.x < 0)
            {
                aimIndicator.transform.localRotation = (Quaternion.Euler(0, 0, angle));
            }
            else
            {
                aimIndicator.transform.localRotation = (Quaternion.Euler(0, 0, -angle));
            }
        }
        else//based on direction ball is faceing
        {
            aimIndicator.transform.localRotation = (Quaternion.Euler(0, 0, -transform.localRotation.eulerAngles.y));
        }
    }

    public void Shoot()
    {
        rb.drag = 0.5f;
        rb.freezeRotation = false;
        //based on direction being faced
        if (lvlController.GetGameState() == LevelController.gameState.putting)
        {
            Vector3 aimForce = transform.forward;
            aimForce.y = 0;

            rb.AddForce(aimForce * (powerOfShot), ForceMode.Impulse);
            lvlController.SetGameState(LevelController.gameState.shooting);
            power--;
        }
        //not based on direction being faced
        /*if (lvlController.GetGameState() == LevelController.gameState.putting)
        {
            rb.AddForce(aimDirect * (powerOfShot), ForceMode.Impulse);
            lvlController.SetGameState(LevelController.gameState.shooting);
            power--;
        }*/
    }


    //debug purposes
    private void PuttPlayer(Vector3 direction, float power)
    {
        direction = Vector3.Normalize(direction);

        direction.z = direction.y;
        direction.y = 0;
        Debug.Log(direction);

        powerOutput = power * direction;
        rb.AddForce(direction * power, ForceMode.Impulse);
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


    ///Code to Rotate player based on button input <summary>
    
    //Gonna have to edit this, saving for later
    
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

    public void CheckRotation()
    {
        if (isRotating)
        {
            if (rotateLeft)
            {
                this.transform.Rotate(0f, -5f, 0f);
            }
            else if (rotateRight)
            {
                this.transform.Rotate(0f, 5f, 0f);
            }
        }
    }
    
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
