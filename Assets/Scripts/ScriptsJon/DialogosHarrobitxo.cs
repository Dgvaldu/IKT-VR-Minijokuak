using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogosHarrobitxo : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    private Queue<string> colaDialogos = new Queue<string>();
   
    Textos texto;
    [SerializeField] TextMeshProUGUI textoPantalla;

    [SerializeField]
    private bool sceneChangeDialog;
    [SerializeField]
    private string scene;

    [SerializeField]
    ObjetoInteractable OInteractable;

    public void ActivarCartel(Textos textObjeto)
    {
        //Debug.Log("MetodoActivarCartel");
        anim.SetBool("Dialogos", true);
        texto = textObjeto;
        textoPantalla.text = texto.arrayTextos[0];
    }

    public void ActivaTexto()
    {
        colaDialogos.Clear();
        foreach (string textoGuardar in texto.arrayTextos)
        {
            colaDialogos.Enqueue(textoGuardar);
        }
        SiguienteFrase();

    }

    public void SiguienteFrase()
    {
        if (colaDialogos.Count == 0)
        {
            CierraCartel();
            OInteractable.isQueueFilled = false;
            if (sceneChangeDialog)
            {
                SceneManager.LoadScene(scene);
            }
            return; 
        }

        string fraseActual = colaDialogos.Dequeue();
        textoPantalla.text = fraseActual;

    }
    public void CierraCartel()
    {
        anim.SetBool("Dialogos", false);
        OInteractable.isQueueFilled = false;
    }
}
