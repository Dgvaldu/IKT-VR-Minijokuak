using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class ObjetoInteractable : MonoBehaviour
{
    public Textos textos;
    [SerializeField]
    private DialogosHarrobitxo controlDialogos;

    public bool isQueueFilled = false;

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
            controlDialogos.denbora = true;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controlDialogos.CierraCartel();
            controlDialogos.denbora = false;
        }
        controlDialogos.Tiempo = 4f;
    }
}
