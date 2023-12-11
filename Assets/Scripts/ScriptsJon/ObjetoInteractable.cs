using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjetoInteractable : MonoBehaviour
{
    public Textos textos;
    [SerializeField]
    private ControlDialogos controlDialogos;

    private bool isQueueFilled = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controlDialogos.ActivarCartel(textos);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(!isQueueFilled)
            {
                controlDialogos.ActivaTexto();
                isQueueFilled = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                controlDialogos.SiguienteFrase();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controlDialogos.CierraCartel();
        }
    }
}
