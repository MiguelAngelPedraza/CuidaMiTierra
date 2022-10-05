using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;

public class ChangePlayers : MonoBehaviour
{
    [SerializeField] GameObject[] animals;
    [Space]
    [Header("Selected Animal")]
    [SerializeField] int indexCharacter;
    [SerializeField] bool canChange;
    [Space]
    [Header("Camera Select")]
    //[SerializeField] Cinemachine.CinemachineFreeLook cmCamera;
    [SerializeField] Cinemachine.CinemachineVirtualCamera vrCamera;
    [Space]
    [Header("Restart WolfVision")]
    [SerializeField] GameObject postProcess;
    [SerializeField] ActivateOutlines outline;
    

    
    void Start()
    {

        for (int i = 1; i < animals.Length; i++)
        {

            animals[i].gameObject.FindComponent<ComponentSelector>().enabled = false;
            animals[i].gameObject.FindComponent<MalbersInput>().enabled = false;
            vrCamera.m_Follow = animals[i].transform;
            vrCamera.LookAt = animals[i].transform;

        }
        if (animals.Length > 0)
        {
            animals[0].gameObject.FindComponent<ComponentSelector>().enabled = true;
            animals[0].gameObject.FindComponent<MalbersInput>().enabled = true;

            vrCamera.m_Follow = animals[0].transform;
            vrCamera.LookAt = animals[0].transform;

        }

    }

    void Update()
    {
        if (canChange) Select();
        
    }
    bool changeNow;
    public void CharacterChange()
    {
        changeNow=true;
    }
    public void Select()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || changeNow==true)
        {
            postProcess.SetActive(false);//desactiva el pp del lobo (si estaba activado)
            outline.ToggleOutline(false);//desactiva el outline del mundo (si estaba activado)
            changeNow=false;
            indexCharacter++;

            if (indexCharacter < animals.Length)
            {
                animals[indexCharacter - 1].gameObject.FindComponent<ComponentSelector>().enabled = false;
                animals[indexCharacter - 1].gameObject.FindComponent<MalbersInput>().enabled = false;

                animals[indexCharacter].gameObject.FindComponent<ComponentSelector>().enabled = true;
                animals[indexCharacter].gameObject.FindComponent<MalbersInput>().enabled = true;

                vrCamera.m_Follow = animals[indexCharacter].transform;
                vrCamera.LookAt = animals[indexCharacter].transform;

            }
            else
            {
                animals[indexCharacter - 1].gameObject.FindComponent<ComponentSelector>().enabled = false;
                animals[indexCharacter - 1].gameObject.FindComponent<MalbersInput>().enabled = false;

                indexCharacter = 0;

                animals[indexCharacter].gameObject.FindComponent<ComponentSelector>().enabled = true;
                animals[indexCharacter].gameObject.FindComponent<MalbersInput>().enabled = true;
                vrCamera.m_Follow = animals[indexCharacter].transform;
                vrCamera.LookAt = animals[indexCharacter].transform;
            }
        }
    }
}
