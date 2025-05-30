using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private bool isInRange = false;
    private bool isPickedUp = false;
    private Transform player;

    void Update()
    {
        // Check for E key press when in range and not yet picked up
        if (isInRange && !isPickedUp && Input.GetKeyDown(KeyCode.E))
        {
            isPickedUp = true;
        }

        // If picked up, follow the player
        if (isPickedUp && player != null)
        {
            transform.position = player.position + new Vector3(0, 1.5f, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            player = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            player = null;
        }
    }

    public bool IsPickedUp()
    {
        return isPickedUp;
    }
}
