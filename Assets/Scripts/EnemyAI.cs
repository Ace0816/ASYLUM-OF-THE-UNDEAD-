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

    //parameters
    [SerializeField] float chaseRange = 3.5f;
    float distanceToTarget;

    private void Update()
    {
        //uses that chase range and distance to target parameter to set up that the enemy will only begin moving once the player enters that chase range

        distanceToTarget = Vector3.Distance(transform.position, target.position);
        //This method calculates the shortest distance between the two input points

        if (distanceToTarget <= chaseRange)
        {
            nMA.SetDestination(target.transform.position);
            //uses the NavMeshAgent Variable to update the destination to the players position, allowing the NMA to be able to calcuate a new path.
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
