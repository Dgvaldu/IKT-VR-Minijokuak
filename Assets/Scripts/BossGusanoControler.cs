using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossGusanoControler : MonoBehaviour
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

    Transform[] locators;

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
                if (distance <= chaseRange)
                {
                    //animator.SetBool("Iswalking", true);
                    animator.SetBool("IsAttacking", true);
                    animator.SetBool("IsPutazo", false);

                    if (distance <= attackRange)
                    {
                        //Enemy tiro egiteko erreferentzia ejekutatu

                        //animator.SetBool("Iswalking", false);
                        animator.SetBool("IsPutazo", true);
                        animator.SetBool("IsAttacking", false);
                    }

                }
            }
        }
    }

    public void MeleeAttack()
    {
        gameObject.GetComponent<BossAttack>().MeleeAttack();
    }
    float CalcularElMasCercanoAlPlayer()
    {
        List<float> distancias = new List<float>();
        for (int i = 0; i < locators.Length; i++)
        {
            distancias.Add(Vector3.Distance(player.transform.position, locators[i].transform.position));
        }
        int indice = Array.IndexOf(locators, distancias.Min());
        return distancias.Min();
    }
    Vector3 locatorAleatorio()
    {
        int random = UnityEngine.Random.Range(0, locators.Length);
        return locators[random].transform.position;
    }
}
