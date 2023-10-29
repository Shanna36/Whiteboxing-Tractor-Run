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

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the playerRb if needed
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

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wheat"))
        {
          
            Destroy(other.gameObject);
           //add slider info  for wheat ingestion here

        }
    }
}