using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField]
    GameObject BossBullet;
    [SerializeField]
    Transform bulletOrigin;
    [SerializeField]
    float bulletSpeed;
    [SerializeField]
    float shootRate;
    [SerializeField]
    float MeleeRate;

    float lastShoot;
    float lastMelee;

    private PlayerHealth playerHealth;
    public AudioSource BossBala;

    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    public void Shoot()
    {
        if (lastShoot + shootRate <= Time.time)
        {           

            lastShoot = Time.time;
            GameObject bulletClone = Instantiate(BossBullet, bulletOrigin.position, bulletOrigin.rotation);
            bulletClone.GetComponent<Rigidbody>().velocity = bulletOrigin.forward * bulletSpeed;
            BossBala.Play();
            Destroy(bulletClone, 3);
        }
    }

    public void MeleeAttack()
    {
        if (lastMelee + MeleeRate <= Time.time)
        {
            Debug.Log("MELEE");

            lastMelee = Time.time;
            playerHealth.TakeDamage(16);
        }
    }
}
