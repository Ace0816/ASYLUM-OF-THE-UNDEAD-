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
    [SerializeField] float chaseRange = 5f;
    float distanceToTarget;

    private void Update()
    {
        //uses the NavMeshAgent Variable to update the destination to the players position, allowing the NMA to be able to calcuate a new path.
        nMA.SetDestination(target.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
