using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Player player;

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
        player = GameObject.Find("Player").GetComponent<Player>();
        player.life = 3;
        player.timeCount = 5;
        player.revive = true;
        player.hit = true;
        player.morreu = false;
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("GameOver");



    }
}
