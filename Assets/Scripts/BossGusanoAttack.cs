using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGusanoAttack : MonoBehaviour
{
    [SerializeField]
    float MeleeRate;

    float lastMelee;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
 
    public void MeleeAttack()
    {
        if (lastMelee + MeleeRate <= Time.time)
        {
            Debug.Log("Mele Atraves del suelo");

            lastMelee = Time.time;
            playerHealth.TakeDamage(10);
        }
    }
}
