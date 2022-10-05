using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations.Controller;

public class Hole : MonoBehaviour
{
    [SerializeField] private KeyCode _teleportKey = KeyCode.F;
    private int id = 0;
    public Hole target;
    public MAnimal bunny;
    public bool isInside = false;
    public bool isEnabled;

    private void Start()
    {
        id = Random.Range(0, 100);
        gameObject.name = "Hole " + id;
        target.gameObject.name = "Hole " + id;
    }

    private void Update()
    {
        if (isInside && Input.GetKeyUp(_teleportKey) && isEnabled)
        {
            Debug.Log("Teleported to hole " + id);
            bunny.Teleport(target.transform.position);
            bunny.Mode_Interrupt();
            isInside = false;
            target.isInside = true;
        }
    }

    public void OnAnimalEnter()
    {
        isInside = true;
        bunny.GetComponentInChildren<SoundModulation>().ToggleSneak(true);
    }

    public void OnAnimalExit()
    {
        isInside = false;
        bunny.GetComponentInChildren<SoundModulation>().ToggleSneak(false);
    }

    public void ToggleEnable()
    {
        ToggleEnable(isEnabled);
    }

    public void ToggleEnable(bool mode)
    {
        isEnabled = mode;
    }
}
