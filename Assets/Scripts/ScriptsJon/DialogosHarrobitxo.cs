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
    private Queue<AudioClip> colaAudios = new Queue<AudioClip>();

    Textos texto;
    [SerializeField] TextMeshProUGUI textoPantalla;

    [SerializeField]
    private bool sceneChangeDialog;
    [SerializeField]
    private string scene;

    [SerializeField]
    ObjetoInteractable OInteractable;

    [SerializeField]
    AudioSource audioSource;

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
        colaAudios.Clear();
        foreach (string textoGuardar in texto.arrayTextos)
        {
            colaDialogos.Enqueue(textoGuardar);
        }
        foreach (AudioClip audioGuardar in texto.arrayClips)
        {
            colaAudios.Enqueue(audioGuardar);
        }
        SiguienteFrase();

    }

    public float Tiempo = 4f;
    public bool denbora = false;
    private void Update()
    {
        if (denbora == true)
        {
            if (Tiempo > 0)
            {
                Tiempo -= Time.deltaTime;
            }

            if (Tiempo < 0 && colaDialogos.Count != 0)
            {
                Debug.Log("Siguiente frase");
                SiguienteFrase();
            }

            if (Tiempo < 0 && colaDialogos.Count == 0 && colaAudios.Count == 0)
            {
                //if (colaDialogos.Count == 0 && colaAudios.Count == 0)
                //{
                    CierraCartel();
                    OInteractable.isQueueFilled = false;
                    if (sceneChangeDialog)
                    {
                        SceneManager.LoadScene(scene);
                    }
                    return;
                //}
            }
        }
    }

    public void SiguienteFrase()
    {


        string fraseActual = colaDialogos.Dequeue();
        textoPantalla.text = fraseActual;

        audioSource.clip = colaAudios.Dequeue();
        Tiempo = audioSource.clip.length + 1;
        audioSource.Play();

        Debug.Log(colaAudios.Count + " " + colaAudios.Count);

    }
    public void CierraCartel()
    {
        anim.SetBool("Dialogos", false);
        OInteractable.isQueueFilled = false;
    }
}
