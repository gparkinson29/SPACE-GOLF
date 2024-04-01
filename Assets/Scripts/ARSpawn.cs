using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ARSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject ARObjectPrefab, levelPrefab;
    [SerializeField]
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Vector2 touchPosition;


    // Update is called once per frame
    void Update()
    {
        SpawnLevelAR();
    }



    public void SpawnLevelAR()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchPosition = touch.position;
            }

            if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                if (ARObjectPrefab == null)
                {
                    ARObjectPrefab = Instantiate(levelPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    ARObjectPrefab.transform.position = hitPose.position;
                }
            }
        }
    }

}
