using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunktion : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void Starting()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    public void WinningScene()
    {
        SceneManager.LoadScene(3);
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene(2);
    }
}
