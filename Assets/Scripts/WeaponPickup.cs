using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weapon;
    public GameObject weaponToDestroy;
    private bool canPickUp = false;

    private void Update()
    {
        if(canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(weaponToDestroy);
            weapon.SetActive(true);
            canPickUp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Weapon")
        {
            weaponToDestroy = other.gameObject;
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            canPickUp = false;
            weaponToDestroy = null;
        }
    }
}
