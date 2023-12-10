using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantenerLuzYmas : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
