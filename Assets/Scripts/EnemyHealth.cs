using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Enemy's health points
    float hP = 100f;

    // Reference to the EnemyAI script
    EnemyAI enemyAI;

    // Flag to check if enemy is dead
    bool isDead = false;

    private void Start()
    {
        // Get the EnemyAI component attached to this GameObject
        enemyAI = GetComponent<EnemyAI>();
    }

    // Public method to check if the enemy is dead
    public bool IsDead()
    {
        return isDead;
    }

    // Called when another collider enters this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a weapon
        if (other.tag == "Weapon")
        {
            // Take damage based on the weapon's damage value
            TakeDamage(other.GetComponent<AttackEnemy>().weaponDamage);
            Debug.Log("Enemy Damaged");
        }
    }

    public void TakeDamage(float weaponDamage)
    {
        enemyAI.OnDamageTaken();
        // Reduce health points by the damage amount
        hP -= weaponDamage;
        // Check if health is zero or below
        if (hP <= 0)
        {
            // If already dead, do nothing
            if (isDead) { return;  }
            isDead = true;
            // Trigger the dying animation
            GetComponent<Animator>().SetTrigger("dyingTrigger");
            // Disable the EnemyAI script to stop enemy behavior
            GetComponent<EnemyAI>().enabled = false;
            // Disable the collider to prevent further interactions
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
