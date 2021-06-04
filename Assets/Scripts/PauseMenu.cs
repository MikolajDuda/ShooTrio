using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /* Pausing the game */
    public static bool GamePaused;
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;    // Resume time
        GamePaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;    // Resume time
        GamePaused = false;
    }

    private void Pause()
    {        
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;    // Freeze time
        GamePaused = true;
    }

}
