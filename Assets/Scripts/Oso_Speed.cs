using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oso_Speed : MonoBehaviour
{
    [SerializeField] Animator velocidad;
    [SerializeField] int contadorOso = 1;



    // Start is called before the first frame update
    void Start()
    {
        contadorOso = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Si presiono Tab y estoy en 0 = Lobo sumo o resto el valor de velocidad del lobo

        if (Input.GetKeyDown(KeyCode.Alpha2) && contadorOso <=1)
        {
            contadorOso ++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && contadorOso >= 1)
        {
            contadorOso--;
        }

        switch (contadorOso)
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
