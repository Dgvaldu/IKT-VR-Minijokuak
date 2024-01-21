using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossGusanoHealth : MonoBehaviour
{
    public float health;
    private float MAXhealth = 150;
    [SerializeField]
    Animator Ani;
    [SerializeField]
    private Image BosshealthSprite;
    public AudioSource DeathSound;

    public BossGusanoControler bossController;

    private void Awake()
    {
        BosshealthSprite = GameObject.Find("BossLife").GetComponent<Image>();

    }
    private void Start()
    {
        health = MAXhealth;
    }
    public void TakeDamage(int dmg)
    {
        //Debug.Log("Taking" + dmg + " dmg");
        health -= dmg;
        if (health <= 0)
        {
            health = 0;
            bossController.isDead = true;
            DeathSound.Play();
            Ani.SetTrigger("IsDeath");
        }
        float newFillAmount = health / MAXhealth;
        BosshealthSprite.fillAmount = newFillAmount;
        //Debug.Log(newFillAmount);
        Ani.SetTrigger("IsHit");
    }

    void Destroy()
    {
        SceneManager.LoadScene("Credits");
    }
}
