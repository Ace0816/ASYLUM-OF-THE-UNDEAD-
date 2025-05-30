using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    // Reference to the weapon GameObject that will be activated when picked up.
    public GameObject weapon;
    // Reference to the weapon GameObject in the scene that will be destroyed upon pickup.
    public GameObject weaponToDestroy;
    // Flag to check whether the player is in range to pick up the weapon.
    private bool canPickUp = false;

    private void Update()
    {
        // Check if the player is in range and has pressed the 'E' key
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(weaponToDestroy);
            // Activate the player's weapon (e.g., to make it visible or usable)
            weapon.SetActive(true);
            // Reset the pickup flag
            canPickUp = false;
        }
    }

    // Called when another collider enters this object's trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with is tagged as "Weapon"
        if (other.gameObject.tag == "Weapon")
        {
            // Set the object as the one to be destroyed upon pickup
            weaponToDestroy = other.gameObject;
            // Allow the player to pick up the weapon
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger is a weapon
        if (other.CompareTag("Weapon"))
        {
            // Disallow pickup since the player is no longer in range
            canPickUp = false;
            // Clear the reference to the weapon to be destroyed
            weaponToDestroy = null;
        }
    }
}
