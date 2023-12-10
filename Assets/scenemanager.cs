using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    [SerializeField]
    GameObject[] list;

    [SerializeField]
    string lScene;

    private void Start()
    {
        list = GameObject.FindGameObjectsWithTag("Dianas");
    }

    private void Update()
    {
        loadNewScene();
    }

    private void loadNewScene()
    {
        int CuentaV = 0;

        for (int i = 0; i < list.Length; i++)
        {
            if (!list[i])
            {
                CuentaV++;

            }
        }
        if (CuentaV == list.Length)
        {
            SceneManager.LoadScene(lScene);
        }

    }
}
