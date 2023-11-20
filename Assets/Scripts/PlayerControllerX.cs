using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 50.0f; // I added this variable for turning
    private Rigidbody playerRb;
    private float horizontalInput; // Declare horizontalInput
    private float forwardInput;    // Declare forwardInput
    public Camera sideViewCamera;
    public Camera topCamera; 
    public KeyCode switchKey; 

    // Start is called before the first frame update
    void Start()
    {
       
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // We move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // We turn the Vehicle
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

     if (Input.GetKeyDown(switchKey))
     {
        sideViewCamera.enabled = !sideViewCamera.enabled;
        topCamera.enabled = !topCamera.enabled; 
     }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log ("Collided with" + other.gameObject.name);
        if(other.CompareTag("Wheat"))
        {
          
            Destroy(other.gameObject);
           //add slider info  for wheat ingestion here

        }
    }
}