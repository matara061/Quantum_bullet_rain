using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void Sair()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void Desistir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }

    public void Continue()
    {

    }
}
