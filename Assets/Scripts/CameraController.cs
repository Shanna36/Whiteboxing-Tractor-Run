using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Camera sideViewCamera; 
    public Camera topCamera;

    private Vector3 sideCameraOffset = new Vector3(19, 13, -22); // Offset for side camera
    private Vector3 topCameraOffset = new Vector3(8, 11, 6); // Offset for top camera

    void Update()
    {
        // Check which camera is active and set position accordingly
        if (sideViewCamera.enabled)
        {
            sideViewCamera.transform.position = player.transform.position + sideCameraOffset;
        }
        else if (topCamera.enabled)
        {
            topCamera.transform.position = player.transform.position + topCameraOffset;
        }
    }
}
