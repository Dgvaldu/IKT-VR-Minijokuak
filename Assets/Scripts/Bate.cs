using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bate : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Matar");
            Destroy(collision.gameObject);
        }
    }
    
}
