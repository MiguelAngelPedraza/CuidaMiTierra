using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liebre_Speed : MonoBehaviour
{
    [SerializeField] Animator velocidad;
    [SerializeField] int contadorLiebre = 1;



    // Start is called before the first frame update
    void Start()
    {
        contadorLiebre = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Si presiono Tab y estoy en 0 = Lobo sumo o resto el valor de velocidad del lobo

        if (Input.GetKeyDown(KeyCode.Alpha2) && contadorLiebre <=1)
        {
            contadorLiebre ++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && contadorLiebre >= 1)
        {
            contadorLiebre--;
        }

        switch (contadorLiebre)
        {
            case 0:
                //Debug.Log("Lobo Camina LENTO");
                velocidad.SetInteger("VELOCIDAD", 0);
                break;
            case 1:
                //Debug.Log("Lobo Camina NORMAL");
                velocidad.SetInteger("VELOCIDAD", 1);
                break;
            case 2:
                //Debug.Log("Lobo Camina RÁPIDO");
                velocidad.SetInteger("VELOCIDAD", 2);
                break;

        }
    }
}
