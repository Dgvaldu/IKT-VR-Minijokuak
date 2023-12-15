using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenuScript : MonoBehaviour
{
    public void BackMenu()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenu"));
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
