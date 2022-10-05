using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SaltoEscena : MonoBehaviour
{
    public static event Action OnTransition;
    

    public void CargarScene(string nombreScene)
    {

        StartCoroutine(SceneLoad(nombreScene));
        
    }

    public IEnumerator SceneLoad(string nombreScene)
    {
        SaltoEscena.OnTransition.Invoke();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nombreScene);
    }

}
