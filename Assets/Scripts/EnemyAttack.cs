using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Reference to the PlayerHealth script, set in the Unity Inspector
    [SerializeField] PlayerHealth pH;
    // Amount of damage this enemy deals to the player
    float damage = 25f;

    // This method is triggered by an animation event set in the enemies attack animation
    public void AttackHitEvent()
    {
        // If no PlayerHealth reference is assigned, exit early
        if (pH == null) { return; }
        // Apply damage to the player
        pH.TakeDamage(damage);
        Debug.Log("Player Damaged");
    }
}
