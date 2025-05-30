using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerHealth handles the player's health, damage intake, and game-over logic
public class PlayerHealth : MonoBehaviour
{
    // Player's starting health points (HP)
    float hP = 200f;
    // Reference to the Game Over UI element to display upon death
    public GameObject gameOverUI;
    // Reference to a component that provides a visual damage flash effect
    public DamageFlash damageFlash;

    // Method to reduce HP when the player takes damage
    public void TakeDamage(float enemyAttackDmg)
    {
        // Subtract the enemy's damage from the player's HP
        hP -= enemyAttackDmg;

        // Trigger a flash effect to visually indicate damage
        if (damageFlash != null)
            damageFlash.TriggerFlash();

        // If HP reaches 0 or below, trigger the death logic
        if (hP <= 0)
        {
            Die();
        }
    }

    // Method to handle what happens when the player dies
    private void Die()
    {
        // Pause the game
        Time.timeScale = 0f;

        // Unlock and show the cursor so the player can interact with the UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Display the Game Over UI if it's assigned
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }
}
