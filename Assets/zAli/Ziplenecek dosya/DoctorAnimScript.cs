using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoctorAnimScript : MonoBehaviour
{
    public float Health = 100f;
    public Animator anim;
    public NavMeshAgent agent;
    public Transform player;
    public GameObject projectile;
    public GameObject ProjectileGenerator;
    public LayerMask whatIsGround, whatIsPlayer;

    // Attacking

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // States

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInattackRange;

    private void Awake()
    {
        player = GameObject.Find("karakter").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInattackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && playerInattackRange) Attack();
    }
    private void Attack()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        
        anim.SetTrigger("attack");

        if (!alreadyAttacked)
        {
            ///Attack code is here
            Rigidbody rb = Instantiate(projectile, ProjectileGenerator.transform.position, transform.localRotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0) Invoke(nameof(DestroyEnemy), 4f);
    }
    private void DestroyEnemy()
    {
        anim.SetTrigger("death");
        Destroy(gameObject);
    }
}
