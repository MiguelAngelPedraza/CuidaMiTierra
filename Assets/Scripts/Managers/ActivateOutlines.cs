using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOutlines : MonoBehaviour
{
    [SerializeField] Outline[] outline;
    void Start()
    {
        outline = FindObjectsOfType<Outline>();
        for (int i = 0; i < outline.Length; i++)
            {
                outline[i].enabled = false;
            }
    }

    public void ToggleOutline(bool activate)
    {
        for (int i = 0; i < outline.Length; i++)
            {
                outline[i].enabled = activate;
            }

    }
}
