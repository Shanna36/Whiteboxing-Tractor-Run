using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSimplified : MonoBehaviour
{
    
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    // Add these variables if they're needed
    public KeyCode switchKey; 
    public Camera sideViewCamera;
    public Camera topCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            sideViewCamera.enabled = !sideViewCamera.enabled;
            topCamera.enabled = !topCamera.enabled; 
        }
    }
    
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        
        foreach (AxleInfo axleInfo in axleInfos) 
        {
            if (axleInfo.steering) 
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) 
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with" + other.gameObject.name);
        if (other.CompareTag("Wheat"))
        {
            Destroy(other.gameObject);
            //add slider info for wheat ingestion here
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
