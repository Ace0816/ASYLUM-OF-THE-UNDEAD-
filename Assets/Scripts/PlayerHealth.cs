using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float hP = 200f;

    public void TakeDamage(float enemyAttackDmg)
    {
        hP -= enemyAttackDmg;
        if (hP <= 0)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
