using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void CargarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
