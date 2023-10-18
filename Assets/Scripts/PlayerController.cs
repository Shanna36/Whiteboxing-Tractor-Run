
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        horizontalInput *= -1f;

        // Combine the input values into a single vector
        Vector3 movement = new Vector3(verticalInput, 0, horizontalInput);

        // Apply the movement to the player's position
        transform.Translate(movement * Time.deltaTime * speed);

    }
}
