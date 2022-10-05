using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveImages : MonoBehaviour
{
    //---------------------- PROPIEDADES SERIALIZADAS ----------------------

    [SerializeField] float mousePosX;
    [SerializeField] float movimientoX = 20f;
    //---------------------- PROPIEDADES PRIVADAS -------------------------


    void Start()
    {

    }


    void Update()
    {
        mousePosX = Input.mousePosition.x;

        this.GetComponent<RectTransform>().position = new Vector2(
            ( mousePosX / Screen.width) * movimientoX + (Screen.width / 2),transform.position.y);
    }
}

