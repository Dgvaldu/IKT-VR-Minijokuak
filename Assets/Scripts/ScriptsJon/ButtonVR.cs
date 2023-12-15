using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonVR : MonoBehaviour
{
    public GameObject boton;
    //public UnityEvent onPress;
    //public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    public Collider collider;

    public Animator AnimColli;

    [SerializeField]
    TextMeshProUGUI timerText;
    public float timer = 100f;
    bool denbora = false;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        denbora = false;
        AnimColli = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Proba1");
        if (!isPressed)
        {
            boton.transform.localPosition = new Vector3(0, 0.004f, 0);
            presser = other.gameObject;
            //onPress.Invoke();
            //sound.Play();
            isPressed = true;
            AnimColli.SetTrigger("Open");
            //collider.enabled = false;
            //collider.GetComponent<BoxCollider>().enabled = false;
        }
        denbora = true;    
    }

    private void Update()
    {
        if(denbora == true)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(timer / 60);
                int seconds = Mathf.FloorToInt(timer % 60);
                timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
                //collider.enabled = false;
            }
            if (timer < 0)
            {
                SceneManager.LoadScene("dead");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            boton.transform.localPosition = new Vector3(0, 0.02f, 0);
            //onRelease.Invoke();
            isPressed = false;
        }
    }

}
