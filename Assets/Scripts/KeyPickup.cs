using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows a key object to be picked up by the player when in range and pressing the "E" key.
// Once picked up, the key follows the player.
public class KeyPickup : MonoBehaviour
{
    // Flag to determine if the player is in range to pick up the key
    private bool isInRange = false;
    // Flag to determine if the key has been picked up
    private bool isPickedUp = false;
    // Reference to the player's transform
    private Transform player;

    void Update()
    {
        // Check if the player is in range, the key hasn't been picked up yet,
        // and the player presses the "E" key
        if (isInRange && !isPickedUp && Input.GetKeyDown(KeyCode.E))
        {
            isPickedUp = true;
        }

        // If the key has been picked up and we have a reference to the player
        if (isPickedUp && player != null)
        {
            // Make the key follow the player, slightly above their position
            transform.position = player.position + new Vector3(0, 1.5f, 0);
        }
    }

    // Called when another collider enters the trigger collider attached to the key
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Set the key to be in range and store the player's transform
            isInRange = true;
            player = other.transform;
        }
    }

    // Called when another collider exits the trigger collider
    void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Mark the key as out of range and clear the player's transform reference
            isInRange = false;
            player = null;
        }
    }

    // Public method to check if the key has been picked up
    public bool IsPickedUp()
    {
        return isPickedUp;
    }
}
