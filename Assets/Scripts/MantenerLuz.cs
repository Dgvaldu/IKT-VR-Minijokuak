using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantenerLuz : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
