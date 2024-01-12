using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField]
    private float attackRate;

    [SerializeField]
    private Health health;    

    public float damageToPlayer;    

    float attackCountdown = 0f;

    public event Action OnAttack;

    private void Start()
    {
        health = GameObject.Find("PlayerController").GetComponent<Health>();
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
            health.TakeDamage(damageToPlayer);
            Debug.Log(transform.name + "is attacking its target");

            OnAttack?.Invoke();
        }
    }
}
