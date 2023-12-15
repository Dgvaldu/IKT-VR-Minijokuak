using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjetoInteractable : MonoBehaviour
{
    public Textos textos;
    [SerializeField]
    private DialogosHarrobitxo controlDialogos;

    public bool isQueueFilled = false;

    public float Tiempo = 3f;
    bool denbora = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controlDialogos.ActivarCartel(textos);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            if(!isQueueFilled)
            {
                controlDialogos.ActivaTexto();
                isQueueFilled = true;
            }            
            denbora = true;            
        }
    }

    private void Update()
    {
        if (denbora == true)
        {
            if (Tiempo > 0)
            {
                Tiempo -= Time.deltaTime;
            }

            if (Tiempo < 0)
            {
                controlDialogos.SiguienteFrase();
                Tiempo = 3f;
            }
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controlDialogos.CierraCartel();
            denbora = false;
        }
        Tiempo = 4f;
    }
}
