using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    bool isPaused;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))isPaused=!isPaused;
        if(isPaused==true)
        {
            Time.timeScale=0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale=1;
            pauseMenu.SetActive(false);
        }
    }
    public void IsPaused()
    {
        isPaused=false;
    }
}
