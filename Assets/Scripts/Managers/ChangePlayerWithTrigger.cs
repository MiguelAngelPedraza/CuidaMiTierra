using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangePlayerWithTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent eventWithTrigger;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ("Animal"))
        {
            Debug.Log("trigger");
            eventWithTrigger.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
