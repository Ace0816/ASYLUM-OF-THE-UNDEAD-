using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //ref to players position
    [SerializeField] Transform target;
    //ref to enemy position
    [SerializeField] NavMeshAgent nMA;
    // Reference to the enemy's Animator component for animations
    [SerializeField] Animator anim;
    // Reference to the enemy's health component to check if dead
    [SerializeField] EnemyHealth eHealth;

    //parameters
    [SerializeField] float chaseRange = 3.5f; // Distance at which enemy starts chasing player
    float distanceToTarget;                   // Current distance from enemy to player
    float turnSpeed = 5f;                     // Speed at which enemy rotates to face player
    float enemyDeceleration = 0.2f;           // Slight offset to control attack start distance

    //states
    bool isAggro = false; // Whether enemy is alerted and actively chasing player

    bool isAttacking = false; // Whether enemy is currently attacking

    // Called when enemy takes damage, makes the enemy aggressive
    public void OnDamageTaken()
    {
        isAggro = true;
    }

    private void Update()
    {
        //uses that chase range and distance to target parameter to set up that the enemy will only begin moving once the player enters that chase range

        distanceToTarget = Vector3.Distance(transform.position, target.position);
        //This method calculates the shortest distance between the two input points

        // If enemy is dead, disable this script and NavMeshAgent to stop all behavior
        if (eHealth.IsDead())
        {
            enabled = false;
            nMA.enabled = false;
        }

        // If enemy is aggro, engage the player (chase/attack)
        if (isAggro)
        {
            EngageTarget();
        }

        // If enemy not aggro yet, but player is within chase range, set aggro to true
        else if (distanceToTarget <= chaseRange)
        {
            isAggro = true;
        }

        // Handle animations related to enemy state
        Animations();
    }

    // Controls enemy behavior when engaged with the target
    private void EngageTarget()
    {
        FaceTarget(); // Rotate to look at player smoothly

        // If player is farther than stopping distance, chase the player
        if (distanceToTarget >= nMA.stoppingDistance)
        {
            ChaseTarget();
        }

        // If player is close enough (considering a small deceleration offset), attack
        if (distanceToTarget - enemyDeceleration <= nMA.stoppingDistance)
        {
            AttackTarget();
        }
    }

    // Sets animation and moves the enemy towards the player
    private void ChaseTarget()
    {
        anim.SetTrigger("movingTrigger"); // Trigger moving animation
        isAttacking = false; // Set attacking flag false while moving
        nMA.SetDestination(target.transform.position); // Set destination for NavMeshAgent to player's position
    }

    // Handles attacking state
    private void AttackTarget()
    {
        isAttacking = true; // Set attacking flag true
        // Could trigger attack animation here if needed
    }

    // Controls animation states (currently just sets isAttacking animation bool true)
    private void Animations()
    {
        anim.SetBool("isAttacking", true);
    }

    // Smoothly rotate enemy to face the player on the horizontal plane
    private void FaceTarget()
    {
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(target.position.x - transform.position.x, 0, target.position.z - transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        //visualises on the enemy asset the chase range
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

   

}
