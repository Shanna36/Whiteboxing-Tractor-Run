using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 500.0f;
    private Rigidbody playerRb;

    public float zUpperBound = 140.0f;
    public float zLowerBound = -154.0f;
    public float xBound = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;  // Ensure physics doesn't affect rotation
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
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

        ConstrainPlayerPosition();
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.z > zUpperBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zUpperBound);
        }
        else if (transform.position.z < zLowerBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLowerBound);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }
}
