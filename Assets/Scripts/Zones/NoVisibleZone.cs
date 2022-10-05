
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoVisibleZone : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Animal"))
        {
            other.FindComponentInRoot<SoundModulation>().ToggleSneak(true);
        }
    }
    public Transform juga;
    public float speed;
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Animal"))
        {
            other.FindComponentInRoot<SoundModulation>().ToggleSneak(false);
        }

        transform.rotation= Quaternion.Slerp(transform.rotation, juga.transform.rotation, speed);
    }
}
