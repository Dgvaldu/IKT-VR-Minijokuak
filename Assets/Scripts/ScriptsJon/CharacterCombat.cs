using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField]
    private float attackRate;

    [SerializeField]
    private PlayerHealth health;    

    public float damageToPlayer;    

    float attackCountdown = 0f;

    public event Action OnAttack;

    private void Start()
    {
        health = GameObject.Find("PlayerController").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        attackCountdown -= Time.deltaTime;
    }

    public void AttackEnemyToPlayer()
    {
        if (attackCountdown <= 0f)
        {
            attackCountdown = 0.7f / attackRate;
            //health.TakeDamage(damageToPlayer);
            //Debug.Log(transform.name + "is attacking its target");

            //OnAttack?.Invoke();
        }
    }
    private void OnCollisionEnter(Collision coli)
    {
        if (coli.gameObject.CompareTag("Bate") || coli.gameObject.CompareTag("Escudo"))
        {
            health.TakeDamage(0);
            Debug.Log(transform.name + "is not attacking its target");
        }
        else if (coli.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(damageToPlayer);
            Debug.Log(transform.name + "is attacking its target");

            OnAttack?.Invoke();
        }
    }
}
