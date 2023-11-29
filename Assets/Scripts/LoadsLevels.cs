using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadsLevels : MonoBehaviour
{
    [SerializeField]
    Dropdown ParaJugar;

    [SerializeField]
    AudioSource MenuMusica;

    [SerializeField]
    Slider Barra;

    [SerializeField]
    Slider Barra1;

    [SerializeField]
    Slider Barra2;

    [SerializeField]
    AudioSource MenuVoces;

    [SerializeField]
    Light DLight;

    /*[SerializeField]
    GameObject DLight;*/

    public void EscogerMJuego()
    {
        string izena = ParaJugar.options[ParaJugar.value].text;
        SceneManager.LoadScene(izena);
    }
    public void Exit() 
    {
        Application.Quit();
    }
    public void SubOBajMusica()
    {
        MenuMusica.volume = Barra.value; 
    }
    public void SubOBajLuz()
    {
        DLight.intensity = Barra2.value * 5f;
        //DLight.GetComponent<Light>().intensity = Barra.value * 5f;
    }
    /*private void Update()
    {
        DLight.intensity = Barra.value * 5f;
    }*/
    public void SubOBajVoces()
    {
        MenuVoces.volume = Barra1.value;
    }
}
