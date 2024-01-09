using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //No le qita daño al Player
            Debug.Log("No hay daño");
        }
    }
}
