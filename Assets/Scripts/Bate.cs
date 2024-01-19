using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bate : MonoBehaviour
{
    [SerializeField]
    BossHealth RecivirDaño;
    [SerializeField]
    Enemy vida;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Matar");
            vida.IsAtacking = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            RecivirDaño.TakeDamage(20);
            Destroy(collision.gameObject);
        }
    }
}
