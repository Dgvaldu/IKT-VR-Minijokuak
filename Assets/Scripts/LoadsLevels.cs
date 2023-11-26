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
}
