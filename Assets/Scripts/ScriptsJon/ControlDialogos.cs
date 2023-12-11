using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ControlDialogos : MonoBehaviour
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

    public void ActivarCartel(Textos textObjeto)
    {
        Debug.Log("MetodoActivarCartel");
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
            if(sceneChangeDialog)
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
        anim.SetBool("Cartel", false);
    }
}
