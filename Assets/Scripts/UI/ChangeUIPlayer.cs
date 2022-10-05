using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUIPlayer : MonoBehaviour
{
    [SerializeField] Animator changeUI;
    [SerializeField] int contador = 1; 
    [SerializeField] GameObject lobo, liebre, oso;


    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            contador++;
        }


        switch (contador)
        {
            case 0:
                //Debug.Log("Lento");
                changeUI.SetInteger("Change",0);
                lobo.SetActive(true);
                liebre.SetActive(false);
                oso.SetActive(false);
                break;
            case 1:
                //Debug.Log("Normal");
                changeUI.SetInteger("Change", 1);
                lobo.SetActive(false);
                oso.SetActive(true);
                liebre.SetActive(false);
                break;
            case 2:
                //Debug.Log("Rápido");
                changeUI.SetInteger("Change", 2);
                lobo.SetActive(false);
                oso.SetActive(false);
                liebre.SetActive(true);
                break;
        }

        if(contador==3)contador=0;
    }
}
