using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Direccionador : MonoBehaviour
{
    [SerializeField] private float tiempoEspera = 15f;
    

    public static event Action Oncontinue;

    private void Update()
    {
        if(Time.time > tiempoEspera)
        {
            Direccionador.Oncontinue.Invoke();
        }
    }
}

