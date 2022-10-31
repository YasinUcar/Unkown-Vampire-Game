using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI2 : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange;
    NavMeshAgent navMeshAgent;
    bool isProvoked = false;
    float distanceToTarget;
    public Animator anim;
    void Start()
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
    public void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
        anim.SetTrigger("run");
        anim.SetTrigger("wrun");
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
