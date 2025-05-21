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

    //parameters
    [SerializeField] float chaseRange = 3.5f;
    float distanceToTarget;
    float turnSpeed = 5f;

    //states
    bool isAggro = false;

    public void OnDamageTaken()
    {
        isAggro = true;
    }

    private void Update()
    {
        //uses that chase range and distance to target parameter to set up that the enemy will only begin moving once the player enters that chase range

        distanceToTarget = Vector3.Distance(transform.position, target.position);
        //This method calculates the shortest distance between the two input points

        if (distanceToTarget <= chaseRange)
        {
            nMA.SetDestination(target.transform.position);
            //uses the NavMeshAgent Variable to update the destination to the players position, allowing the NMA to be able to calcuate a new path.
            anim.SetTrigger("movingTrigger");
        }
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
