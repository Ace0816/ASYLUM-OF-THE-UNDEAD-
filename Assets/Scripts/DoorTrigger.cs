using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    //reference key object in scene
    public GameObject keyObject; 
    //ref gameover UI element
    public GameObject gameOverUI; 

    void OnTriggerEnter(Collider other)
    {
        //check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            //get the KeyPickup component from the key object
            KeyPickup keyPickup = keyObject.GetComponent<KeyPickup>();

            //check if the key exists and has been pickd up by the player
            if (keyPickup != null && keyPickup.IsPickedUp())
            {
                // Show Game Over UI
                gameOverUI.SetActive(true);

                // pause the game by settig the timesale to 0
                Time.timeScale = 0f;
            }
        }
    }
}
