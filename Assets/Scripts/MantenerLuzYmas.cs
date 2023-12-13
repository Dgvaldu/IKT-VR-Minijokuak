using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantenerLuzYmas : MonoBehaviour
{
    public static MantenerLuzYmas Instance;

    private void Start()
    {

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /*private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }*/
}
