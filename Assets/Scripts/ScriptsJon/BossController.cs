using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    float sightRange;
    [SerializeField]
    float chaseRange;
    [SerializeField]
    float attackRange;
    [SerializeField]
    float minDistance;

    GameObject player;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float speed = 8.0f;

    [SerializeField]
    private Transform bulletOrigin;
    public bool isDead;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position, chaseRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, sightRange);
    }

    private void Update()
    {
        if (!isDead)
        {
            float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

            if (distance <= sightRange)
            {
                //animator.SetBool("Iswalking", false);                
                animator.SetBool("IsAttacking", false);
                gameObject.transform.LookAt(player.transform);
                bulletOrigin.LookAt(player.transform);
                if (distance <= chaseRange)
                {
                    //animator.SetBool("Iswalking", true);
                    animator.SetBool("IsAttacking", true);
                    animator.SetBool("IsPutazo", false);                                      

                    Vector3 newVector = gameObject.transform.forward * speed;
                    newVector.y = 0;
                    if (distance >= minDistance)
                    {                        
                        gameObject.GetComponent<Rigidbody>().velocity = newVector;
                    }

                    if (distance <= attackRange)
                    {
                        //Enemy tiro egiteko erreferentzia ejekutatu

                        //animator.SetBool("Iswalking", false);
                        animator.SetBool("IsPutazo", true);
                        animator.SetBool("IsAttacking", false);
                        speed = 0.5f;
                    }

                }
            }
        }        
    }

    public void MeleeAttack()
    {
        gameObject.GetComponent<BossAttack>().MeleeAttack();
    }

    void Shoot()
    {
        gameObject.GetComponent<BossAttack>().Shoot();
    }

}
