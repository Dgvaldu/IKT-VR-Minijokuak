using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantenerPlayer : MonoBehaviour
{
    public static MantenerPlayer Instance;

    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (this != Instance)
        {
            Debug.Log("Destroy extra Player");
            Destroy(gameObject);
        }
    }
}
