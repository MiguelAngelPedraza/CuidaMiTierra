using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioPersonaje : MonoBehaviour
{
    [SerializeField] int NumeroPersonaje;
    [SerializeField] Animator SeleccionAnimal;
    [SerializeField] Animator SeleccionVelocidad;
    // Start is called before the first frame update
    void Start()
    {
        NumeroPersonaje = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)&& NumeroPersonaje < 3)
        {
            NumeroPersonaje++;
        }

        if (NumeroPersonaje >= 3)
        {
            NumeroPersonaje = 0;
        }

        switch (NumeroPersonaje)
        {
            case 0:
                Debug.Log("LOBO SELECCIONADO");
                SeleccionAnimal.SetInteger("Animal", 0);
                SeleccionVelocidad.SetInteger("Animal",0);
                break;
            case 1:
                Debug.Log("OSO SELECCIONADO");
                SeleccionAnimal.SetInteger("Animal", 1);
                SeleccionVelocidad.SetInteger("Animal", 1);
                break;
            case 2:
                Debug.Log("LIEBRE SELECCIONADA");
                SeleccionAnimal.SetInteger("Animal", 2);
                SeleccionVelocidad.SetInteger("Animal", 2);
                break;
        }
    }
}
