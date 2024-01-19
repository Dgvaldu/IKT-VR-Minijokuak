using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatAttack : MonoBehaviour
{
    [SerializeField]
    float MeleeRate;

    float lastMelee;

    private PlayerHealth playerHealth;
    public AudioSource EnbestidaSonido;

    private void Start()
    {
        playerHealth = GameObject.Find("PlayerConByE").GetComponent<PlayerHealth>();
    }    

    public void MeleeAttack()
    {
        if (lastMelee + MeleeRate <= Time.time)
        {
            Debug.Log("MELEE");

            EnbestidaSonido.Play();
            lastMelee = Time.time;
            playerHealth.TakeDamage(16);
        }
    }
}
