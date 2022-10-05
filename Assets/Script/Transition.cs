using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField]private Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        transition = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SaltoEscena.OnTransition += Activar;
    }

    private void Activar()
    {
        transition.SetTrigger("Activar");
    }
}
