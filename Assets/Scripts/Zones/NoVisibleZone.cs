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
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Animal"))
        {
            other.FindComponentInRoot<SoundModulation>().ToggleSneak(false);
        }
    }
}
