using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{   
    public static Health Instance;

    private void Awake()
    {
        Instance = this;
    }   

    public float health = 100;
    [SerializeField]
    private Image healthBar;

    public void Heal(float healAmount)
    {
        health += healAmount;
        if (health < 100)
        {
            health = 100;
        }
        healthBar.fillAmount = health / health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            SceneManager.LoadScene("dead");
        }
        float newFillAmount = health / 100.0f;

        healthBar.fillAmount = newFillAmount;
    }
}