using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sneak : MonoBehaviour
{
    public SoundModulation sound;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
            sound.ToggleSneak();
        
    }
}
