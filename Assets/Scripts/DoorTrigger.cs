using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject keyObject;  // Assign the Key GameObject in the Inspector
    public GameObject gameOverUI; // Assign the Game Over UI Panel in the Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyPickup keyPickup = keyObject.GetComponent<KeyPickup>();

            if (keyPickup != null && keyPickup.IsPickedUp())
            {
                // Show Game Over UI
                gameOverUI.SetActive(true);

                // Optionally stop the game
                Time.timeScale = 0f;
            }
        }
    }
}
