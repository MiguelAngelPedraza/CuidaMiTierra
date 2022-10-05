using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boton : MonoBehaviour
{
    [SerializeField] GameObject boton;
    [SerializeField] GameObject gifUI;
    [SerializeField] GameObject textUI;
    [SerializeField] AudioSource FxComplete;
    

    // Update is called once per frame
    void Update()
    {
        Direccionador.Oncontinue += Activar;
    }

    private void Activar()
    {
        StartCoroutine(BotonActivo());
    }

    IEnumerator BotonActivo()
    {
        gifUI.SetActive(false);
        textUI.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        FxComplete.Play();
        FxComplete.enabled = true;
        boton.SetActive(true);

    }
}
