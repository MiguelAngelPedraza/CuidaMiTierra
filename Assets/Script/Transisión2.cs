using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transisión2 : MonoBehaviour
{
    [SerializeField] Animator Transition;

    public void ActivarTransición2()
    {
        Transition.SetTrigger("Activar");
    }


}
