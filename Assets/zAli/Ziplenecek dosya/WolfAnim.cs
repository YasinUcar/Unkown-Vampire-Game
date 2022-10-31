using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfAnim : MonoBehaviour
{
    //public float Health = 100f;
    public Animator anim;
    public NavMeshAgent agent;
    //public Transform player;
    //public LayerMask whatIsGround, whatIsPlayer;

    // Attacking

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    [SerializeField] Transform target;
    [SerializeField] float chaseRange;
    NavMeshAgent navMeshAgent;
    bool isProvoked = false;
    float distanceToTarget;
    // States

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInattackRange;

    private void Awake()
    {

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }

    }
    void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);

    }
    void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
