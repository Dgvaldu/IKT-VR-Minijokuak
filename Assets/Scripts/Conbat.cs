using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Conbat : MonoBehaviour
{
    [SerializeField]
    private float attackRate;

    [SerializeField]
    private HealthManager EnemyHealdManager;

    [SerializeField]
    private HealthManager PlayerHealdManager;

    public float damageToPlayer;

    float attackCountdown = 0f;

    public float restarStamine;


    public event Action OnAttack;
    private void Update()
    {
        attackCountdown -= Time.deltaTime;
    }

    public void Attack()
    {
        if (attackCountdown <= 0f)
        {
            attackCountdown = 1f / attackRate;
            //AttackLogika
            Debug.Log(transform.name + " is attacking its target");

            OnAttack.Invoke();
            //OnAttack?.Invoke();

            //eraso egin
            EnemyHealdManager.TakeDamage(damageToPlayer);
        }
    }
}
