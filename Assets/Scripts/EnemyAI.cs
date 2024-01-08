using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    Transform target;
    [SerializeField]
    Animator animator;
    [SerializeField]
    LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    Vector3 walkPoint;
    Vector3 distanceToWalkPoint;
    [SerializeField]
    float walkPointRange;
    bool isWalkingPointSet;
    //Chase
    [SerializeField]
    float sightRange;
    bool isPlayerInSightRange;

    //Attack
    /*[SerializeField]
    private CharacterCombat characterCombat;*/
    [SerializeField]
    float attackRange;
    bool isPlayerInAttackRange;


    [SerializeField]
    private Transform sphereOrigins;

    private void Update()
    {
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
            agent.SetDestination(walkPoint);

        }

        distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            isWalkingPointSet = false;
        }
    }

    void ChasePlayer()
    {
        Debug.Log("Chasing");
        agent.SetDestination(target.position);
        CheckDistanceFromPlayer();
        FaceTarget();
    }

    void AttackPlayer()
    {
        Debug.Log("Attacking");
        agent.SetDestination(target.position);
        CheckDistanceFromPlayer();
        FaceTarget();
        //characterCombat.Attack();
    }

    void CheckDistanceFromPlayer()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceFromPlayer < 2f)
        {
            agent.SetDestination(gameObject.transform.position);
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
