using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform; //assigned in inspector

    public float distanceFromPlayer = 2.0f; // Distance in meters from the player
    public float heightAbovePlayer = 10.0f; // Height in meters above the player

    void Update()
    {
        // Check if the playerTransform is assigned
        if (playerTransform == null)
        {
            Debug.LogWarning("Player transform not assigned in the inspector!");
            return;
        }

        // Calculate the camera's new position based on player's position and offsets
        Vector3 newPosition = playerTransform.position - playerTransform.forward * distanceFromPlayer + Vector3.up * heightAbovePlayer;

        // Set the camera's position to the new calculated position
        transform.position = newPosition;

        // Make the camera look at the player's position
        transform.LookAt(playerTransform.position + playerTransform.up * heightAbovePlayer);
    }
}
