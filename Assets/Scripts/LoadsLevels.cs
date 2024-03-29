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

    #region Musica
    [SerializeField]
    public AudioSource MenuMusicaYmas;

    [SerializeField]
    AudioClip MenuMusica;

    [SerializeField]
    AudioClip MantenimenMusica;

    [SerializeField]
    AudioClip SistemaMusica;

    [SerializeField]
    AudioClip SareMusica;

    [SerializeField]
    AudioClip SegurMusica;

    [SerializeField]
    AudioClip ZerbiMusica;

    [SerializeField]
    AudioClip Sistema2Musica;
    #endregion
    
    #region Barras
    [SerializeField]
    Slider Barra;

    [SerializeField]
    Slider Barra1;

    [SerializeField]
    Slider Barra2;
    #endregion

    #region Voces
    [SerializeField]
    AudioSource MenuVoces;

    [SerializeField]
    AudioClip MenuVoces1Prueba;

    #endregion

    [SerializeField]
    Light DLight;

    float FB;
    float FB1;
    float FB2;

    /*[SerializeField]
    GameObject DLight;*/

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void EscogerMJuego()
    {
        string izena = ParaJugar.options[ParaJugar.value].text;
        SceneManager.LoadScene(izena);
    }
    public void MantenimenduPlayZona() 
    {
        SceneManager.LoadScene("Jolastu Mantenimendua minijokua");
    }
    public void SareakPlayZona()
    {
        SceneManager.LoadScene("Jolastu Sareak minijokua");
    }
    public void SegurtasunPlayZona()
    {
        SceneManager.LoadScene("Jolastu Segurtasun minijokua");
    }
    public void SistemakPlayZona()
    {
        SceneManager.LoadScene("Jolastu Sistemak minijokua");
    }
    public void Sistemak2PlayZona()
    {
        SceneManager.LoadScene("Jolastu Sistemak 2 minijokua");
    }
    public void ZebitzuPlayZona()
    {
        SceneManager.LoadScene("Jolastu Zerbitzuak minijokua");
    }
    public void Exit() 
    {
        Application.Quit();
    }
    
    public void SubOBajMusica()
    {
        MenuMusicaYmas.volume = Barra.value;
        FB = Barra.value;
    }
    public void SubOBajLuz()
    {
        DLight.intensity = Barra2.value * 5f;
        //DLight.GetComponent<Light>().intensity = Barra.value * 5f;
        FB2 = Barra2.value;
    }
    /*private void Update()
    {
        
    }*/
    public void SubOBajVoces()
    {
        MenuVoces.volume = Barra1.value;
        MenuVoces.Play();
        FB1 = Barra1.value;
    }
    [SerializeField] int voces_index = 0;
    public void OnLevelWasLoaded(int level)
    {

        if (level == 0)
        {
            MenuMusicaYmas.clip = MenuMusica;
            MenuMusicaYmas.Play();
        }
        else if (level == 1) 
        {
            MenuMusicaYmas.clip = MantenimenMusica;
            MenuMusicaYmas.Play();

        }
        if (level == 2) 
        {
            MenuMusicaYmas.clip = SistemaMusica;
            MenuMusicaYmas.Play();
        }
        if (level == 3)
        {
            MenuMusicaYmas.clip = SareMusica;
            MenuMusicaYmas.Play();
        }
        if(level == 4)
        {
            MenuMusicaYmas.clip = SegurMusica;
            MenuMusicaYmas.Play();
        }
        if(level == 5)
        {
            MenuMusicaYmas.clip = ZerbiMusica;
            MenuMusicaYmas.Play();
        }
        if(level == 6)
        {
            MenuMusicaYmas.clip = Sistema2Musica;
            MenuMusicaYmas.Play();
        }
    }
}
