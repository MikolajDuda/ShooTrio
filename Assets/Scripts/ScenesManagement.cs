using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManagement : MonoBehaviour
{
    public void StartFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void StartSecondLevel()
    {
        SceneManager.LoadScene(2);
    }
    
    public void StartThirdLevel()
    {
        SceneManager.LoadScene(3);
    }
    
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
