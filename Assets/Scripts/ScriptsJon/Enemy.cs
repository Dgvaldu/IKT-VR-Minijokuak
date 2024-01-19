using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent enemy;
    [SerializeField]
    public Transform target;
    [SerializeField]
    LayerMask whatIsGround, whatIsPlayer;

    //caminando
    Vector3 walkPoint;
    Vector3 distanceToWalkPoint;
    [SerializeField]
    float walkPointRange;
    bool isWalkingPointSet;
    //Perseguiendo
    [SerializeField]
    float sightRange;
    bool isPlayerInSightRange;

    //Attack
    [SerializeField]
    private CharacterCombat characterCombat;
    [SerializeField]
    float attackRange;
    bool isPlayerInAttackRange;


    [SerializeField]
    private Transform sphereOrigins;

    public bool IsAtacking = false;

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //enemy.SetDestination(target.position);

        isPlayerInSightRange = Physics.CheckSphere(sphereOrigins.position, sightRange, whatIsPlayer);
        isPlayerInAttackRange = Physics.CheckSphere(sphereOrigins.position, attackRange, whatIsPlayer);

        if (!isPlayerInSightRange && !isPlayerInAttackRange) Patrolling();
        if (!isPlayerInAttackRange && isPlayerInSightRange) ChasePlayer();
        if (isPlayerInAttackRange && isPlayerInSightRange) AttackPlayer();
    }    

    void SearchWalkingPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        isWalkingPointSet = true;
    }
    void Patrolling()
    {
        Debug.Log("Patrolling");
        if (!isWalkingPointSet) SearchWalkingPoint();

        if (isWalkingPointSet)
        {
            enemy.SetDestination(walkPoint);
        }

        distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 2f)
        {
            isWalkingPointSet = false;
        }
    }

    void ChasePlayer()
    {
        Debug.Log("Chasing");
        enemy.SetDestination(target.position);
        CheckDistanceFromPlayer();
        FaceTarget();
    }

    void AttackPlayer()
    {
        Debug.Log("Attacking");
        enemy.SetDestination(target.position);
        CheckDistanceFromPlayer();
        FaceTarget();
        characterCombat.AttackEnemyToPlayer();
    }

    void CheckDistanceFromPlayer()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceFromPlayer < 2f)
        {
            enemy.SetDestination(gameObject.transform.position);
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(sphereOrigins.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(sphereOrigins.position, sightRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(sphereOrigins.position, walkPointRange);
    }
}
