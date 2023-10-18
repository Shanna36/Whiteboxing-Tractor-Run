
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 500.0f;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;  // Ensure physics doesn't affect rotation
    }

    // Update is called once per frame
   void Update()
{
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    float rotation = horizontalInput * rotationSpeed * 3 * Time.deltaTime;
    transform.Rotate(Vector3.up, rotation);

    // Forward movement
    if (verticalInput > 0)
    {
        Vector3 forwardMovement = transform.forward * verticalInput * speed;
        transform.Translate(forwardMovement * Time.deltaTime, Space.World);
    }
    // Backward movement
    else if (verticalInput < 0)
    {
        Vector3 backwardMovement = -transform.forward * -verticalInput * speed;
        transform.Translate(backwardMovement * Time.deltaTime, Space.World);
    }
}

}
