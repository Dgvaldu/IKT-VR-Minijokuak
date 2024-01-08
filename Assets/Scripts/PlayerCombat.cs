using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    /*private void Start()
    {
        Bate.GetComponent<Grabbable>().IsGrabbable();
        Escudo.GetComponent<Grabbable>().IsGrabbable();
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.name == "Bate")
            {
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "Escudo")
            {
                //No le qita da�o al Player
                Debug.Log("No hay da�o");
            }

        }
    }
}
