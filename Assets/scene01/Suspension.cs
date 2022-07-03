using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Suspension : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    void Start()
    {
        
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void MenuGame()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);

    }

    public void RestartGame()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        HealthThings.health=HealthThings.MaxHealth;
        HealthBar.HealthCurrent = HealthThings.health;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
