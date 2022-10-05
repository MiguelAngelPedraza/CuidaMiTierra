using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidad : MonoBehaviour
{
    [SerializeField] Animator velocidad;
    [SerializeField] int contador = 1; 


    // Start is called before the first frame update
    void Start()
    {
        contador = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && contador >=1)
        {
            contador--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && contador <=1)
        {
            contador++;
        }

        switch (contador)
        {
            case 0:
                //Debug.Log("Lento");
                velocidad.SetInteger("VELOCIDAD",0);
                break;
            case 1:
                //Debug.Log("Normal");
                velocidad.SetInteger("VELOCIDAD", 1);
                break;
            case 2:
                //Debug.Log("Rápido");
                velocidad.SetInteger("VELOCIDAD", 2);
                break;
        }
    }
}
