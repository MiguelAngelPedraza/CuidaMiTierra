using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    private void Awake()
    {
        gameOverMenu.SetActive(false);
    }
    public void GameOverNow()
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);

    }
    public void ResetScene()
    {
        SceneManager.LoadScene(1);

    }


}
