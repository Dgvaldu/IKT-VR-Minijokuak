using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ButtonVR : MonoBehaviour
{
    public GameObject boton;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            boton.transform.localPosition = new Vector3(0, 0.004f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            boton.transform.localPosition = new Vector3(0, 0.02f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void SpawnText()
    {

    }
}
