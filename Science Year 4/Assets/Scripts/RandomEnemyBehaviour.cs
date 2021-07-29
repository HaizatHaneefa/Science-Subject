using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomEnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    // Patrolling
    public Vector3 walkPoint;
    bool walkPointset;
    public float walkpointRange;

    // Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // States
    public float sightRange, attackRange;
    public bool playerinSightRange, playerInAttackRange;

    float health;

    public Transform[] spwnPoints;

    public Transform spawnBullet;

    [SerializeField] private GameObject projectile;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerinSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerinSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if (playerinSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInAttackRange && playerinSightRange)
        {
            AttackPlayer();
        }
    }

    void Patroling()
    {
        if (!walkPointset)
        {
            SearchWalkPoint();
        }

        if (walkPointset)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distancetowalkpoint = transform.position - walkPoint;

        // walkpoint reached
        if (distancetowalkpoint.magnitude < 1f)
        {
            walkPointset = false;
        }
    }

    void SearchWalkPoint()
    {
        // calculate random point in range
        float randomZ = Random.Range(-walkpointRange, walkpointRange);
        float randomX = Random.Range(-walkpointRange, walkpointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointset = true;
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // attack code here
            GameObject projectilePrefab = Instantiate(projectile, spawnBullet.position, Quaternion.identity);
            projectilePrefab.GetComponent<Rigidbody>().AddForce(spawnBullet.forward * 100f);
            
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
        health -= damage;

        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 2f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
