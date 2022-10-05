using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    //---------------- PROPIEDADES SERIALIZADAS

    [SerializeField] AudioSource FuenteSonido;

    public void SonidoBoton()
    {
        FuenteSonido.Play();
        FuenteSonido.enabled = true;
    }

}
