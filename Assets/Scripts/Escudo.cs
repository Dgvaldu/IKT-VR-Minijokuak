using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    [SerializeField]
    GameObject escudo;

    [SerializeField]
    Collider Coli;

    [SerializeField]
    bool ParaDefender;

    private void Start()
    {
        ParaDefender = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ParaDefender == true)
        {
            Coli.GetComponent<Collider>().isTrigger = false;
        }
        else
        {
            Coli.GetComponent<Collider>().isTrigger = true;
        }
    }
}
