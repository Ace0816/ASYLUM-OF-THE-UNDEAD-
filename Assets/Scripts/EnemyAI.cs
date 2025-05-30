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

    [SerializeField] Animator anim;
    [SerializeField] EnemyHealth eHealth;

    //parameters
    [SerializeField] float chaseRange = 3.5f;
    float distanceToTarget;
    float turnSpeed = 5f;
    float enemyDeceleration = 0.2f;

    //states
    bool isAggro = false;

    bool isAttacking = false;

    public void OnDamageTaken()
    {
        isAggro = true;
    }

    private void Update()
    {
        //uses that chase range and distance to target parameter to set up that the enemy will only begin moving once the player enters that chase range

        distanceToTarget = Vector3.Distance(transform.position, target.position);
        //This method calculates the shortest distance between the two input points

        if (eHealth.IsDead())
        {
            enabled = false;
            nMA.enabled = false;
        }

        if (isAggro)
        {
            EngageTarget();
        }

        else if (distanceToTarget <= chaseRange)
        {
            isAggro = true;
        }

        Animations();
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= nMA.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget - enemyDeceleration <= nMA.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        anim.SetTrigger("movingTrigger");
        isAttacking = false;
        //anim.SetBool("isAttacking", false);
        nMA.SetDestination(target.transform.position);
    }

    private void AttackTarget()
    {
        isAttacking = true;
        //anim.SetBool("isAttacking", true);
    }

    private void Animations()
    {
        anim.SetBool("isAttacking", true);
    }

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
