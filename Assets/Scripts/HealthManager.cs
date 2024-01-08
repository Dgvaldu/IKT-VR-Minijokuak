using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;


    private void Awake()
    {
        instance = this;
    }
    public float health = 100f;
    public Image healthBar;

    [SerializeField]
    private HealthManager PlayerDamage;
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (PlayerDamage.health <= 0)
        {
            //health = 0;
            SceneManager.LoadScene("GameOver");
        }
        
        float newFillAmount = health / 100.0f;
        
        IsFillamount(healthBar, health, 100f);
    }
    void IsFillamount(Image Numero, float estadistica, float estadisticaMax)
    {
        if (/*Barra*/Numero)
        {
            Numero.fillAmount = estadistica / estadisticaMax;
        }
    }

    //Enemy health manager
    public static HealthManager Enemyinstance;

    [SerializeField]
    private HealthManager EnemyDamage;

    public float Enemyhealth = 1f;
    //public Image healthBarNotFound;

    public void TakeDamageEnemy(float damage)
    {
        Enemyhealth -= damage;

        if (EnemyDamage.health <= 0)
        {
            Die();
        }
        float newFillAmount = Enemyhealth / 1.0f;  
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
