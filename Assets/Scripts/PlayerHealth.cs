using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float hP = 200f;
    public GameObject gameOverUI;
    public DamageFlash damageFlash;

    public void TakeDamage(float enemyAttackDmg)
    {
        hP -= enemyAttackDmg;

        if (damageFlash != null)
            damageFlash.TriggerFlash();

        if (hP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }
}
